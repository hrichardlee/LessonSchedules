using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Windows.Xps.Packaging;
using System.IO.Packaging;
using System.Windows.Xps;
using System.Windows.Documents;

namespace LessonSchedules {
    public partial class Form1 : Form {
        #region general

        LSConfiguration config;

        public Form1() {
            InitializeComponent();
            config = new LSConfiguration();
        }

        private int nTotalLessons;

        private static DateTime JustDate( DateTime d ) {
            return new DateTime( d.Year, d.Month, d.Day );
        }

        private void LoadForm( object sender, EventArgs e ) {
            //set dates
            FirstLessonDate.Value = DateTime.Now;
            LastLessonDate.Value = DateTime.Now + new TimeSpan( 7 * 36, 0, 0, 0 );
            SchoolYear.Text = DateTime.Now.Year.ToString() + "–" + ( DateTime.Now.Year + 1 ).ToString();

            LoadHolidayList();
            LoadRecitalList();
        }

        //Called when done with entering info, creates the xps document
        private System.Windows.Documents.FixedDocument CreateSchedule() {
            DateTime FirstDay = JustDate( FirstLessonDate.Value );
            DateTime LastDay = JustDate( LastLessonDate.Value );

            if( FirstDay.DayOfWeek != LastDay.DayOfWeek ) {
                MessageBox.Show( "The first and last dates must be the same day of the week." );
                return null;
            } else if( FirstDay >= LastDay ) {
                MessageBox.Show( "The last lesson date must be after the first lesson date" );
                return null;
            }

            string AppDirectory = new FileInfo( Application.ExecutablePath ).DirectoryName;

            CreateScheduleClass csc = new CreateScheduleClass( AppDirectory );
            return csc.CreateSchedule(
                    StudentName.Text,
                    SchoolYear.Text.Replace( '-', '–' ),    //replaces hyphens with en dashes
                    FirstDay,
                    LastDay,
                    nTotalLessons,
                    CurrentHolidayList.Items.Cast<Holiday>(),
                    CurrentRecitalList.Items.Cast<Recital>(),
                    PaymentRate.Value,
                    RoundAmount.Value,
                    (int )UserPaymentCount.Value,
                    FirstStudentName.Text,
                    FirstStudentRate.Value,
                    SecondStudentName.Text,
                    SecondStudentRate.Value,
                    LessonTime.Text,
                    UserMonthlyPayment.Value
                );
        }

        private void ViewSchedule( object sender, EventArgs e ) {
            System.Windows.Documents.FixedDocument fd = CreateSchedule();
            if( fd != null ) {
                DisplayXPS d = new DisplayXPS( fd );
                d.Show();
            }
        }

        private void SaveSchedule( object sender, EventArgs e ) {
            System.Windows.Documents.FixedDocument fd = CreateSchedule();
            if( fd != null ) {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XPS Documents (*.xps)|*.xps";
                saveFileDialog.FileName = StudentName.Text + " " + SchoolYear.Text + ".xps";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );
                if( saveFileDialog.ShowDialog( this ) == DialogResult.OK ) {
                    Stream file = saveFileDialog.OpenFile();
                    if( file != null ) {
                        Package package = Package.Open( file, FileMode.Create );
                        XpsDocument theDoc = new XpsDocument( package );
                        XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter( theDoc );
                        writer.Write( fd );
                        theDoc.Close();
                        package.Close();
                        file.Close();
                    } else {
                        MessageBox.Show( "Error creating file" );
                    }
                }
            }
        }

        //called when the user changes the lesson dates
        private void UpdateTotalLessons( object sender, EventArgs e ) {
            nTotalLessons =
                (
                    (
                        (
                            JustDate( LastLessonDate.Value )
                            -
                            JustDate( FirstLessonDate.Value )
                        ).Days
                    ) / 7
                ) + 1;
            TotalLessons.Text = nTotalLessons.ToString();
        }

        #endregion general


        #region holidays

        private bool isEdit;

        private void LoadHolidayList() {
            HolidayList.DataSource = config.HolidayList;
            HolidayList.SelectedIndex = -1;
            ResetAddEditHoliday();
        }

        private void ResetAddEditHoliday() {
            HolidayFirstDay.Value = DateTime.Now;
            HolidayLastDay.Value = DateTime.Now;
            HolidayName.Text = string.Empty;
        }

        private void CreateNewHoliday( object sender, EventArgs e ) {
            isEdit = false;
            AddEditHoliday.Enabled = true;
            ResetAddEditHoliday();
            HolidayName.Focus();
        }

        private void EditHoliday( object sender, EventArgs e ) {
            if( HolidayList.SelectedItem == null ) {
                MessageBox.Show( "You must select a holiday before you can edit it" );
                return;
            }

            isEdit = true;
            AddEditHoliday.Enabled = true;
            HolidayName.Focus();
        }

        private void SetHolidayDate( object sender, EventArgs e ) {
            HolidayLastDay.Value = HolidayFirstDay.Value;
        }

        private void CancelHoliday( object sender, EventArgs e ) {
            AddEditHoliday.Enabled = false;
        }

        private void SaveHoliday( object sender, EventArgs e ) {
            DateTime LastDay = JustDate( HolidayLastDay.Value );
            DateTime FirstDay = JustDate( HolidayFirstDay.Value );
            if( LastDay < FirstDay ) {
                MessageBox.Show( @"The first day of the holiday must be before or on the same day
                    as the last day of the holiday." );
                return;
            }

            Holiday toAdd = new Holiday( HolidayName.Text, FirstDay, LastDay );

            Holiday old = null;
            if( isEdit ) old = ( Holiday )HolidayList.SelectedItem;
            if( isEdit ? !config.UpdateHoliday( old.Name, toAdd )
                       : !config.AddHoliday( toAdd ) ) {
                MessageBox.Show( @"That name is already in use. Either select that holiday in the list
                    above and edit it or choose a name for this holiday." );
                HolidayName.Focus();
                return;
            }

            AddEditHoliday.Enabled = false;
            LoadHolidayList();
            if( isEdit ) CurrentHolidayList.Items.Clear();
        }

        private void HolidaySelected( object sender, EventArgs e ) {
            if( HolidayList.SelectedItem != null ) {
                Holiday h = ( Holiday )HolidayList.SelectedItem;
                HolidayFirstDay.Value = h.FirstDay;
                HolidayLastDay.Value = h.LastDay;
                HolidayName.Text = h.Name;
            }
            AddEditHoliday.Enabled = false;
        }

        private void DeleteHoliday( object sender, EventArgs e ) {
            if( HolidayList.SelectedItem == null ) {
                MessageBox.Show( "You must select a holiday before you can delete it" );
                return;
            }

            config.DeleteHoliday( ( ( Holiday )HolidayList.SelectedItem ).Name );
            LoadHolidayList();
            CurrentHolidayList.Items.Clear();
        }

        private void AddHolidayToSchedule( object sender, EventArgs e ) {
            if( HolidayList.SelectedItem == null ) {
                MessageBox.Show( "You must select a holiday before you can add it to the schedule" );
                return;
            }

            if( CurrentHolidayList.Items.Contains( HolidayList.SelectedItem ) ) {
                MessageBox.Show( "You have already added that holiday to the schedule" );
                return;
            }

            CurrentHolidayList.Items.Add( HolidayList.SelectedItem );
        }

        private void RemoveHolidayFromSchedule( object sender, EventArgs e ) {
            if( CurrentHolidayList.SelectedItem == null ) {
                MessageBox.Show( "You must select a holiday before you can remove it from the schedule" );
                return;
            }

            CurrentHolidayList.Items.Remove( CurrentHolidayList.SelectedItem );
        }

        #endregion holidays


        #region recitals

        private void LoadRecitalList() {
            RecitalList.DataSource = config.RecitalList;
        }

        private void NewRecital( object sender, EventArgs e ) {
            if( !config.AddRecital( new Recital( JustDate( RecitalDate.Value ), RecitalName.Text ) ) ) {
                MessageBox.Show( "That recital date has already been saved." );
                RecitalDate.Focus();
            }

            LoadRecitalList();
        }

        private void AddRecitalToSchedule( object sender, EventArgs e ) {
            if( RecitalList.SelectedItem == null ) {
                MessageBox.Show( "You must select a recital before you can add it to the schedule" );
                return;
            }

            if( CurrentRecitalList.Items.Contains( RecitalList.SelectedItem ) ) {
                MessageBox.Show( "You have already added that recital to the schedule" );
                return;
            }

            CurrentRecitalList.Items.Add( RecitalList.SelectedItem );
        }

        private void RemoveRecitalFromSchedule( object sender, EventArgs e ) {
            if( CurrentRecitalList.SelectedItem == null ) {
                MessageBox.Show( "You must select a holiday before you can remove it from the schedule" );
                return;
            }

            CurrentRecitalList.Items.Remove( CurrentRecitalList.SelectedItem );
        }

        private void DeleteRecital( object sender, EventArgs e ) {
            if( RecitalList.SelectedItem == null ) {
                MessageBox.Show( "You must select a recital before you can delete it" );
                return;
            }

            config.DeleteRecital( ( ( Recital )RecitalList.SelectedItem ).Day );
            LoadRecitalList();
            CurrentRecitalList.Items.Clear();
        }

        #endregion recitals
    }
}
