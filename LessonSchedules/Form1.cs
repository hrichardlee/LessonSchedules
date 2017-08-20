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
        bool validatedGroupNamesOnce;

        public Form1() {
            InitializeComponent();
            config = new LSConfiguration();
            validatedGroupNamesOnce = false;
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
            LoadGLDateList();

            foreach (object item in HolidayList.Items)
                CurrentHolidayList.Items.Add(item);

            Decimal tempDec;
            if (Decimal.TryParse(config.GetGeneralSetting("groupLessonRate"), out tempDec))
                groupLessonRate.Value = tempDec;
            if (Decimal.TryParse(config.GetGeneralSetting("extraFees"), out tempDec))
                extraFees.Value = tempDec;
            if (Decimal.TryParse(config.GetGeneralSetting("roundAmount"), out tempDec))
                RoundAmount.Value = tempDec;
            string tempStr;
            tempStr = config.GetGeneralSetting("groupLessonNameSingular");
            if (tempStr != null)
                groupLessonsNameSingular.Text = tempStr;
            tempStr = config.GetGeneralSetting("groupLessonNamePlural");
            if (tempStr != null)
                groupLessonsNamePlural.Text = tempStr;
            tempStr = config.GetGeneralSetting("glDSMonthStart");
            if (tempStr != null)
                glDSMonthStart.Text = tempStr;
            tempStr = config.GetGeneralSetting("glDSMonthEnd");
            if (tempStr != null)
                glDSMonthEnd.Text = tempStr;

            glDSWeekOfMonth.SelectedIndex = 0;
            glDSDay.SelectedIndex = 0;
        }

        private void groupLessonRate_ValueChanged(object sender, EventArgs e)
        {
            config.SetGeneralSetting("groupLessonRate", groupLessonRate.Value.ToString());
        }

        private void groupLessonNameSingular_TextChanged(object sender, EventArgs e)
        {
            config.SetGeneralSetting("groupLessonNameSingular", groupLessonsNameSingular.Text);
        }

        private void groupLessonsNamePlural_TextChanged(object sender, EventArgs e)
        {
            config.SetGeneralSetting("groupLessonNamePlural", groupLessonsNameSingular.Text);
        }

        private void glDSMonthStart_TextChanged(object sender, EventArgs e)
        {
            config.SetGeneralSetting("glDSMonthStart", glDSMonthStart.Text);
        }

        private void glDSMonthEnd_TextChanged(object sender, EventArgs e)
        {
            config.SetGeneralSetting("glDSMonthEnd", glDSMonthEnd.Text);
        }

        private void RoundAmount_ValueChanged(object sender, EventArgs e)
        {
            config.SetGeneralSetting("roundAmount", RoundAmount.Value.ToString());
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
                    PaymentRate.Value,
                    RoundAmount.Value,
                    (int )UserPaymentCount.Value,
                    FirstStudentName.Text,
                    FirstStudentRate.Value,
                    SecondStudentName.Text,
                    SecondStudentRate.Value,
                    LessonTime.Text,
                    UserMonthlyPayment.Value,
                    participatesInGL.Checked ? config.GLDateList : null,
                    groupLessonRate.Value,
                    groupLessonsNamePlural.Text,
                    groupLessonsNameSingular.Text,
                    FirstStudentGL.Checked,
                    SecondStudentGL.Checked,
                    ExtraTextBox.Text,
                    extraFees.Value,
                    LastMonthSmall.Checked
                );
        }

        private void ViewSchedule( object sender, EventArgs e ) {
            if (!FormValidation())
                return;

            System.Windows.Documents.FixedDocument fd = CreateSchedule();
            if( fd != null ) {
                DisplayXPS d = new DisplayXPS( fd, false );
                d.Show();
            }
        }

        private void SaveSchedule( object sender, EventArgs e ) {
            if (!FormValidation())
                return;
            /* To just make xps and show print dialog from that
            System.Windows.Documents.FixedDocument fd = CreateSchedule();
            if (fd != null)
            {
                DisplayXPS d = new DisplayXPS(fd, true);
                d.Show();
                d.Close();
            }*/

            System.Windows.Documents.FixedDocument fd = CreateSchedule();
            if( fd != null ) {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Documents (*.pdf)|*.pdf";
                saveFileDialog.FileName = StudentName.Text + " " + SchoolYear.Text + ".pdf";

                string tempStr = config.GetGeneralSetting("DefaultDir");
                saveFileDialog.InitialDirectory = string.IsNullOrEmpty(tempStr)
                    ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    : tempStr;
                
                if( saveFileDialog.ShowDialog( this ) == DialogResult.OK ) {
                    String pdfName = saveFileDialog.FileName;
                    String xpsName = pdfName + ".xps";
                    if (File.Exists(xpsName))
                    {
                        MessageBox.Show("Please delete the file: " + xpsName + " and try again");
                        return;
                    }

                    try
                    {
                        //create xps file
                        using (XpsDocument theDoc = new XpsDocument(xpsName, FileAccess.ReadWrite))
                        {
                            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(theDoc);
                            writer.Write(fd);
                        }

                        //convert to pdf
                        PdfSharp.Xps.XpsConverter.Convert(xpsName, pdfName, 0);
                    }
                    finally
                    {
                        File.Delete(xpsName);
                    }

                    config.SetGeneralSetting("DefaultDir", Path.GetDirectoryName(pdfName));
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

        private bool FormValidation()
        {
            if (!string.IsNullOrWhiteSpace(FirstStudentName.Text))
            {
                if ((PaymentRate.Value != FirstStudentRate.Value + SecondStudentRate.Value))
                {
                    if (MessageBox.Show("First student's rate is " + FirstStudentRate.Value +
                            " and second student's rate is " + SecondStudentRate.Value +
                            " but that does not add up to total rate of " + PaymentRate.Value +
                            ". OK to continue creating form or cancel to change rates.",
                        "Warning",
                        MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                        return false;
                }

                if (!FirstStudentGL.Checked && !SecondStudentGL.Checked && participatesInGL.Checked)
                    MessageBox.Show("You cannot have both students as not participating in group lessons but have the overall group lessons panel active.");
            }


            if (!validatedGroupNamesOnce && !groupLessonsNamePlural.Text.StartsWith(groupLessonsNameSingular.Text))
            {
                if (MessageBox.Show("Group lessons name singular is " + groupLessonsNameSingular.Text +
                        "but group lessons name plural is " + groupLessonsNamePlural.Text +
                        ". OK to continue creating form or cancel to change rates.",
                    "Warning",
                    MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                    return false;
                else
                    validatedGroupNamesOnce = true;
            }

            return true;
        }

        private void extraFees_ValueChanged(object sender, EventArgs e)
        {
            config.SetGeneralSetting("extraFees", extraFees.Value.ToString());
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
            if (HolidayName.Text == "")
            {
                MessageBox.Show("The holiday must have a name");
                return;
            }

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

        #region group lessons

        private void LoadGLDateList()
        {
            GLDateList.DataSource = config.GLDateList;
            GLDateList.SelectedIndex = -1;
        }

        private void GLAddSingleDate(object sender, EventArgs e)
        {
            DateTime toAdd = JustDate(GLSingleDate.Value);
            if (!config.AddGLDate(toAdd))
            {
                MessageBox.Show(@"That date is already in the date list.");
                GLSingleDate.Focus();
                return;
            }

            LoadGLDateList();
        }

        private void GLDeleteDate(object sender, EventArgs e)
        {
            if (GLDateList.SelectedItem == null)
            {
                MessageBox.Show("You must select a date before you can delete it");
                return;
            }

            config.DeleteGLDate((DateTime)GLDateList.SelectedItem);
            LoadGLDateList();
        }

        private void GLDeleteAll(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all of the dates for group lessons?",
                "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                config.DeleteAllGLDates();
                LoadGLDateList();
            }
        }

        private void ToggleParticipateInGL(object sender, EventArgs e)
        {
            glGeneralOptions.Enabled =
                glAddDateManually.Enabled =
                glDatesList.Enabled =
                glDSAddSeries.Enabled =
                participatesInGL.Checked;

            if (participatesInGL.Checked && !FirstStudentGL.Checked && !SecondStudentGL.Checked)
                FirstStudentGL.Checked =
                SecondStudentGL.Checked =
                participatesInGL.Checked;

            if (!participatesInGL.Checked)
                FirstStudentGL.Checked =
                SecondStudentGL.Checked =
                participatesInGL.Checked;
        }

        private void EachStudentGLChanged(object sender, EventArgs e)
        {
            if (!FirstStudentGL.Checked && !SecondStudentGL.Checked)
                participatesInGL.Checked = false;
            if (FirstStudentGL.Checked || SecondStudentGL.Checked)
                participatesInGL.Checked = true;
        }

        private void glDSAdd(object sender, EventArgs e)
        {
            int monthStart, monthEnd;
            DayOfWeek day;
            try
            {
                monthStart = int.Parse(glDSMonthStart.Text);
                monthEnd = int.Parse(glDSMonthEnd.Text);
                day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), glDSDay.Text);
            }
            catch (FormatException)
            {
                bailOnGLDS();
                return;
            }

            TimeSpan daySpan = new TimeSpan(1, 0, 0, 0);
            TimeSpan weekSpan = new TimeSpan(7, 0, 0, 0);
            int currYear = FirstLessonDate.Value.Year;
            int currMonth = monthStart;

            while (currMonth != monthEnd + 1)
            {
                DateTime currDateTime = new DateTime(currYear, currMonth, 1);
                while (currDateTime.DayOfWeek != day)
                    currDateTime = currDateTime + daySpan;
                //now we are at first day of week

                switch (glDSWeekOfMonth.Text.ToLower())
                {
                    case "1st":
                        break;
                    case "2nd":
                        currDateTime += weekSpan;
                        break;
                    case "3rd":
                        currDateTime += weekSpan + weekSpan;
                        break;
                    case "4th":
                        currDateTime += weekSpan + weekSpan + weekSpan;
                        break;
                    case "last":
                        while ((currDateTime + weekSpan).Month == currDateTime.Month)
                            currDateTime += weekSpan;
                        break;
                    default:
                        bailOnGLDS();
                        return;
                }

                if (!config.AddGLDate(currDateTime))
                {
                    bailOnGLDS();
                    return;
                }

                if (currMonth == 12)
                {
                    currYear++;
                    currMonth = 1;
                }
                else
                {
                    currMonth++;
                }
            }

            LoadGLDateList();
        }

        private void bailOnGLDS()
        {
            LoadGLDateList();
            MessageBox.Show("Generic error. Try again.");
        }
        #endregion

    }
}
