namespace LessonSchedules {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstLessonDate = new System.Windows.Forms.DateTimePicker();
            this.LastLessonDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.TextBox();
            this.SchoolYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalLessons = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.LessonTime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddEditHoliday = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HolidayName = new System.Windows.Forms.TextBox();
            this.HolidayLastDay = new System.Windows.Forms.DateTimePicker();
            this.HolidayFirstDay = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CurrentHolidayList = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.HolidayList = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.RecitalName = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.RecitalDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.CurrentRecitalList = new System.Windows.Forms.ListBox();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.RecitalList = new System.Windows.Forms.ListBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.UserPaymentCount = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.RoundAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.PaymentRate = new System.Windows.Forms.NumericUpDown();
            this.button9 = new System.Windows.Forms.Button();
            this.FirstStudentRate = new System.Windows.Forms.NumericUpDown();
            this.SecondStudentRate = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.FirstStudentName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SecondStudentName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.UserMonthlyPayment = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.AddEditHoliday.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPaymentCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoundAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstStudentRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondStudentRate)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMonthlyPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First lesson is on:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last lesson is on:";
            // 
            // FirstLessonDate
            // 
            this.FirstLessonDate.CustomFormat = "dddd, M/d/yyyy";
            this.FirstLessonDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FirstLessonDate.Location = new System.Drawing.Point(370, 24);
            this.FirstLessonDate.Name = "FirstLessonDate";
            this.FirstLessonDate.Size = new System.Drawing.Size(163, 20);
            this.FirstLessonDate.TabIndex = 3;
            this.FirstLessonDate.ValueChanged += new System.EventHandler(this.UpdateTotalLessons);
            // 
            // LastLessonDate
            // 
            this.LastLessonDate.CustomFormat = "dddd, M/d/yyyy";
            this.LastLessonDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.LastLessonDate.Location = new System.Drawing.Point(370, 50);
            this.LastLessonDate.Name = "LastLessonDate";
            this.LastLessonDate.Size = new System.Drawing.Size(163, 20);
            this.LastLessonDate.TabIndex = 4;
            this.LastLessonDate.ValueChanged += new System.EventHandler(this.UpdateTotalLessons);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "View and Print Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ViewSchedule);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Student Name(s):";
            // 
            // StudentName
            // 
            this.StudentName.Location = new System.Drawing.Point(112, 24);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(133, 20);
            this.StudentName.TabIndex = 7;
            // 
            // SchoolYear
            // 
            this.SchoolYear.Location = new System.Drawing.Point(112, 49);
            this.SchoolYear.Name = "SchoolYear";
            this.SchoolYear.Size = new System.Drawing.Size(133, 20);
            this.SchoolYear.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "School Year:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(570, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total Weeks:";
            // 
            // TotalLessons
            // 
            this.TotalLessons.Enabled = false;
            this.TotalLessons.Location = new System.Drawing.Point(666, 24);
            this.TotalLessons.Name = "TotalLessons";
            this.TotalLessons.Size = new System.Drawing.Size(163, 20);
            this.TotalLessons.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.LessonTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TotalLessons);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SchoolYear);
            this.groupBox1.Controls.Add(this.FirstLessonDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LastLessonDate);
            this.groupBox1.Controls.Add(this.StudentName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Information";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(571, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Lesson Time:";
            // 
            // LessonTime
            // 
            this.LessonTime.Location = new System.Drawing.Point(666, 49);
            this.LessonTime.Name = "LessonTime";
            this.LessonTime.Size = new System.Drawing.Size(163, 20);
            this.LessonTime.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddEditHoliday);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 317);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Holidays";
            // 
            // AddEditHoliday
            // 
            this.AddEditHoliday.Controls.Add(this.button13);
            this.AddEditHoliday.Controls.Add(this.button12);
            this.AddEditHoliday.Controls.Add(this.label10);
            this.AddEditHoliday.Controls.Add(this.label7);
            this.AddEditHoliday.Controls.Add(this.label1);
            this.AddEditHoliday.Controls.Add(this.HolidayName);
            this.AddEditHoliday.Controls.Add(this.HolidayLastDay);
            this.AddEditHoliday.Controls.Add(this.HolidayFirstDay);
            this.AddEditHoliday.Enabled = false;
            this.AddEditHoliday.Location = new System.Drawing.Point(324, 23);
            this.AddEditHoliday.Name = "AddEditHoliday";
            this.AddEditHoliday.Size = new System.Drawing.Size(244, 138);
            this.AddEditHoliday.TabIndex = 11;
            this.AddEditHoliday.TabStop = false;
            this.AddEditHoliday.Text = "Add/Edit Holiday";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(76, 107);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 7;
            this.button13.Text = "Cancel";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.CancelHoliday);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(157, 107);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 6;
            this.button12.Text = "Save";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.SaveHoliday);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ends on:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Begins on:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // HolidayName
            // 
            this.HolidayName.Location = new System.Drawing.Point(69, 19);
            this.HolidayName.Name = "HolidayName";
            this.HolidayName.Size = new System.Drawing.Size(163, 20);
            this.HolidayName.TabIndex = 2;
            // 
            // HolidayLastDay
            // 
            this.HolidayLastDay.CustomFormat = "dddd, M/d/yyyy";
            this.HolidayLastDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HolidayLastDay.Location = new System.Drawing.Point(69, 71);
            this.HolidayLastDay.Name = "HolidayLastDay";
            this.HolidayLastDay.Size = new System.Drawing.Size(163, 20);
            this.HolidayLastDay.TabIndex = 1;
            // 
            // HolidayFirstDay
            // 
            this.HolidayFirstDay.CustomFormat = "dddd, M/d/yyyy";
            this.HolidayFirstDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HolidayFirstDay.Location = new System.Drawing.Point(69, 45);
            this.HolidayFirstDay.Name = "HolidayFirstDay";
            this.HolidayFirstDay.Size = new System.Drawing.Size(163, 20);
            this.HolidayFirstDay.TabIndex = 0;
            this.HolidayFirstDay.ValueChanged += new System.EventHandler(this.SetHolidayDate);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CurrentHolidayList);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(11, 167);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(169, 139);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Holidays currently in schedule";
            // 
            // CurrentHolidayList
            // 
            this.CurrentHolidayList.FormattingEnabled = true;
            this.CurrentHolidayList.Location = new System.Drawing.Point(6, 19);
            this.CurrentHolidayList.Name = "CurrentHolidayList";
            this.CurrentHolidayList.Size = new System.Drawing.Size(149, 82);
            this.CurrentHolidayList.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Remove From Schedule";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RemoveHolidayFromSchedule);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.HolidayList);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Location = new System.Drawing.Point(11, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(307, 142);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Saved Holidays";
            // 
            // HolidayList
            // 
            this.HolidayList.FormattingEnabled = true;
            this.HolidayList.Location = new System.Drawing.Point(9, 19);
            this.HolidayList.Name = "HolidayList";
            this.HolidayList.Size = new System.Drawing.Size(149, 82);
            this.HolidayList.TabIndex = 0;
            this.HolidayList.SelectedIndexChanged += new System.EventHandler(this.HolidaySelected);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(165, 79);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Create New Holiday";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.CreateNewHoliday);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(165, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Delete Selected Holiday";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.DeleteHoliday);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add To Current Schedule";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddHolidayToSchedule);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(165, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Edit Selected Holiday";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.EditHoliday);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Location = new System.Drawing.Point(601, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 317);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recitals";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.RecitalName);
            this.groupBox8.Controls.Add(this.button7);
            this.groupBox8.Controls.Add(this.RecitalDate);
            this.groupBox8.Location = new System.Drawing.Point(176, 167);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(182, 138);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Add Recital";
            // 
            // RecitalName
            // 
            this.RecitalName.Location = new System.Drawing.Point(7, 15);
            this.RecitalName.Name = "RecitalName";
            this.RecitalName.Size = new System.Drawing.Size(162, 20);
            this.RecitalName.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 67);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(163, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "Add Recital Date";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.NewRecital);
            // 
            // RecitalDate
            // 
            this.RecitalDate.CustomFormat = "dddd, M/d/yyyy";
            this.RecitalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RecitalDate.Location = new System.Drawing.Point(6, 41);
            this.RecitalDate.Name = "RecitalDate";
            this.RecitalDate.Size = new System.Drawing.Size(163, 20);
            this.RecitalDate.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.CurrentRecitalList);
            this.groupBox7.Controls.Add(this.button10);
            this.groupBox7.Location = new System.Drawing.Point(6, 167);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(164, 138);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Recitals currently in schedule";
            // 
            // CurrentRecitalList
            // 
            this.CurrentRecitalList.FormattingEnabled = true;
            this.CurrentRecitalList.Location = new System.Drawing.Point(6, 19);
            this.CurrentRecitalList.Name = "CurrentRecitalList";
            this.CurrentRecitalList.Size = new System.Drawing.Size(149, 82);
            this.CurrentRecitalList.TabIndex = 3;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 108);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(149, 23);
            this.button10.TabIndex = 5;
            this.button10.Text = "Remove From Schedule";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.RemoveRecitalFromSchedule);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.RecitalList);
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Controls.Add(this.button8);
            this.groupBox6.Location = new System.Drawing.Point(6, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(352, 142);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Saved Recitals";
            // 
            // RecitalList
            // 
            this.RecitalList.FormattingEnabled = true;
            this.RecitalList.Location = new System.Drawing.Point(6, 19);
            this.RecitalList.Name = "RecitalList";
            this.RecitalList.Size = new System.Drawing.Size(149, 82);
            this.RecitalList.TabIndex = 0;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 108);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(149, 23);
            this.button11.TabIndex = 2;
            this.button11.Text = "Add To Current Schedule";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.AddRecitalToSchedule);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(161, 19);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(130, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "Delete Selected Recital";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.DeleteRecital);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Controls.Add(this.UserMonthlyPayment);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.UserPaymentCount);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.RoundAmount);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.PaymentRate);
            this.groupBox9.Location = new System.Drawing.Point(12, 421);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(686, 197);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Payments";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(17, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 26);
            this.label8.TabIndex = 10;
            this.label8.Text = "Leave this as 0 to have the payments be on the first week of every month";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(212, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Total Payment Dates";
            // 
            // UserPaymentCount
            // 
            this.UserPaymentCount.DecimalPlaces = 2;
            this.UserPaymentCount.Location = new System.Drawing.Point(324, 77);
            this.UserPaymentCount.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.UserPaymentCount.Name = "UserPaymentCount";
            this.UserPaymentCount.Size = new System.Drawing.Size(79, 20);
            this.UserPaymentCount.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Round to Nearest $";
            // 
            // RoundAmount
            // 
            this.RoundAmount.DecimalPlaces = 2;
            this.RoundAmount.Location = new System.Drawing.Point(132, 45);
            this.RoundAmount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RoundAmount.Name = "RoundAmount";
            this.RoundAmount.Size = new System.Drawing.Size(107, 20);
            this.RoundAmount.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Total Rate per Week";
            // 
            // PaymentRate
            // 
            this.PaymentRate.DecimalPlaces = 2;
            this.PaymentRate.Location = new System.Drawing.Point(132, 19);
            this.PaymentRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PaymentRate.Name = "PaymentRate";
            this.PaymentRate.Size = new System.Drawing.Size(107, 20);
            this.PaymentRate.TabIndex = 2;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(714, 467);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(261, 34);
            this.button9.TabIndex = 16;
            this.button9.Text = "Save Schedule";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.SaveSchedule);
            // 
            // FirstStudentRate
            // 
            this.FirstStudentRate.DecimalPlaces = 2;
            this.FirstStudentRate.Location = new System.Drawing.Point(236, 40);
            this.FirstStudentRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FirstStudentRate.Name = "FirstStudentRate";
            this.FirstStudentRate.Size = new System.Drawing.Size(107, 20);
            this.FirstStudentRate.TabIndex = 10;
            // 
            // SecondStudentRate
            // 
            this.SecondStudentRate.DecimalPlaces = 2;
            this.SecondStudentRate.Location = new System.Drawing.Point(236, 72);
            this.SecondStudentRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SecondStudentRate.Name = "SecondStudentRate";
            this.SecondStudentRate.Size = new System.Drawing.Size(107, 20);
            this.SecondStudentRate.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(-1, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "First Student";
            // 
            // FirstStudentName
            // 
            this.FirstStudentName.Location = new System.Drawing.Point(90, 40);
            this.FirstStudentName.Name = "FirstStudentName";
            this.FirstStudentName.Size = new System.Drawing.Size(134, 20);
            this.FirstStudentName.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(-4, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Second Student";
            // 
            // SecondStudentName
            // 
            this.SecondStudentName.Location = new System.Drawing.Point(90, 71);
            this.SecondStudentName.Name = "SecondStudentName";
            this.SecondStudentName.Size = new System.Drawing.Size(134, 20);
            this.SecondStudentName.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(91, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(235, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Rate";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Controls.Add(this.FirstStudentRate);
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.SecondStudentRate);
            this.groupBox10.Controls.Add(this.SecondStudentName);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.FirstStudentName);
            this.groupBox10.Location = new System.Drawing.Point(601, 518);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(368, 100);
            this.groupBox10.TabIndex = 17;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Leave This Blank If There Is Only One Student";
            // 
            // UserMonthlyPayment
            // 
            this.UserMonthlyPayment.DecimalPlaces = 2;
            this.UserMonthlyPayment.Location = new System.Drawing.Point(345, 110);
            this.UserMonthlyPayment.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.UserMonthlyPayment.Name = "UserMonthlyPayment";
            this.UserMonthlyPayment.Size = new System.Drawing.Size(79, 20);
            this.UserMonthlyPayment.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(212, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Regular Payment Amount";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(17, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(189, 59);
            this.label19.TabIndex = 13;
            this.label19.Text = "Leave this as 0 to have the payment be automatically calculated. If this is not " +
                "zero, the \"Round to Nearest\" value will be ignored";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 639);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Lesson Schedule Maker";
            this.Load += new System.EventHandler(this.LoadForm);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.AddEditHoliday.ResumeLayout(false);
            this.AddEditHoliday.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPaymentCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoundAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstStudentRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondStudentRate)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMonthlyPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FirstLessonDate;
        private System.Windows.Forms.DateTimePicker LastLessonDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StudentName;
        private System.Windows.Forms.TextBox SchoolYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TotalLessons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox HolidayList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox CurrentHolidayList;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListBox CurrentRecitalList;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ListBox RecitalList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox AddEditHoliday;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HolidayName;
        private System.Windows.Forms.DateTimePicker HolidayLastDay;
        private System.Windows.Forms.DateTimePicker HolidayFirstDay;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DateTimePicker RecitalDate;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown PaymentRate;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox RecitalName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown RoundAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown UserPaymentCount;
        private System.Windows.Forms.NumericUpDown SecondStudentRate;
        private System.Windows.Forms.NumericUpDown FirstStudentRate;
        private System.Windows.Forms.TextBox FirstStudentName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SecondStudentName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox LessonTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown UserMonthlyPayment;
    }
}

