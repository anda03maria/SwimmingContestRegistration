using System.ComponentModel;

namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.cityTB = new System.Windows.Forms.TextBox();
            this.postalCodeTB = new System.Windows.Forms.TextBox();
            this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.countryTB = new System.Windows.Forms.TextBox();
            this.streetTB = new System.Windows.Forms.TextBox();
            this.raceIdsTB = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.racesGridView = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.styleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfContestantsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.searchNameTB = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.contestantsGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.racesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logOutButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.racesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contestantsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add new contestant";
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(164, 73);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(100, 22);
            this.nameTB.TabIndex = 1;
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(164, 111);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(100, 22);
            this.emailTB.TabIndex = 2;
            // 
            // cityTB
            // 
            this.cityTB.Location = new System.Drawing.Point(164, 152);
            this.cityTB.Name = "cityTB";
            this.cityTB.Size = new System.Drawing.Size(100, 22);
            this.cityTB.TabIndex = 3;
            // 
            // postalCodeTB
            // 
            this.postalCodeTB.Location = new System.Drawing.Point(164, 196);
            this.postalCodeTB.Name = "postalCodeTB";
            this.postalCodeTB.Size = new System.Drawing.Size(100, 22);
            this.postalCodeTB.TabIndex = 4;
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.Location = new System.Drawing.Point(394, 77);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(100, 22);
            this.birthDatePicker.TabIndex = 5;
            // 
            // countryTB
            // 
            this.countryTB.Location = new System.Drawing.Point(394, 115);
            this.countryTB.Name = "countryTB";
            this.countryTB.Size = new System.Drawing.Size(100, 22);
            this.countryTB.TabIndex = 6;
            // 
            // streetTB
            // 
            this.streetTB.Location = new System.Drawing.Point(394, 156);
            this.streetTB.Name = "streetTB";
            this.streetTB.Size = new System.Drawing.Size(100, 22);
            this.streetTB.TabIndex = 7;
            // 
            // raceIdsTB
            // 
            this.raceIdsTB.Location = new System.Drawing.Point(394, 200);
            this.raceIdsTB.Name = "raceIdsTB";
            this.raceIdsTB.Size = new System.Drawing.Size(100, 22);
            this.raceIdsTB.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(523, 190);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(83, 29);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // racesGridView
            // 
            this.racesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.racesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.idColumn, this.distanceColumn, this.styleColumn, this.dateColumn, this.numberOfContestantsColumn });
            this.racesGridView.Location = new System.Drawing.Point(70, 272);
            this.racesGridView.Name = "racesGridView";
            this.racesGridView.RowTemplate.Height = 24;
            this.racesGridView.Size = new System.Drawing.Size(536, 166);
            this.racesGridView.TabIndex = 10;
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "ID";
            this.idColumn.Name = "idColumn";
            // 
            // distanceColumn
            // 
            this.distanceColumn.HeaderText = "Distance";
            this.distanceColumn.Name = "distanceColumn";
            // 
            // styleColumn
            // 
            this.styleColumn.HeaderText = "Style";
            this.styleColumn.Name = "styleColumn";
            // 
            // dateColumn
            // 
            this.dateColumn.HeaderText = "Scheduled Day";
            this.dateColumn.Name = "dateColumn";
            // 
            // numberOfContestantsColumn
            // 
            this.numberOfContestantsColumn.HeaderText = "No. Participants";
            this.numberOfContestantsColumn.Name = "numberOfContestantsColumn";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Available races";
            // 
            // searchNameTB
            // 
            this.searchNameTB.Location = new System.Drawing.Point(70, 477);
            this.searchNameTB.Name = "searchNameTB";
            this.searchNameTB.Size = new System.Drawing.Size(100, 22);
            this.searchNameTB.TabIndex = 12;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(178, 475);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 24);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Search contestants";
            // 
            // contestantsGridView
            // 
            this.contestantsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contestantsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.nameColumn, this.ageColumn, this.racesColumn });
            this.contestantsGridView.Location = new System.Drawing.Point(68, 507);
            this.contestantsGridView.Name = "contestantsGridView";
            this.contestantsGridView.RowTemplate.Height = 24;
            this.contestantsGridView.Size = new System.Drawing.Size(343, 150);
            this.contestantsGridView.TabIndex = 15;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            // 
            // ageColumn
            // 
            this.ageColumn.HeaderText = "Age";
            this.ageColumn.Name = "ageColumn";
            // 
            // racesColumn
            // 
            this.racesColumn.HeaderText = "Races";
            this.racesColumn.Name = "racesColumn";
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(68, 663);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(75, 42);
            this.logOutButton.TabIndex = 16;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(108, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(108, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(118, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "City";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(68, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Postal Code";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(310, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "Birth Date";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(326, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 23);
            this.label9.TabIndex = 22;
            this.label9.Text = "Country";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(335, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "Street";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(314, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 23);
            this.label11.TabIndex = 24;
            this.label11.Text = "Race IDs";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(667, 717);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.contestantsGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchNameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.racesGridView);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.raceIdsTB);
            this.Controls.Add(this.streetTB);
            this.Controls.Add(this.countryTB);
            this.Controls.Add(this.birthDatePicker);
            this.Controls.Add(this.postalCodeTB);
            this.Controls.Add(this.cityTB);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.racesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contestantsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn racesColumn;

        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn styleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfContestantsColumn;

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button logOutButton;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchNameTB;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView contestantsGridView;

        private System.Windows.Forms.DataGridView racesGridView;

        private System.Windows.Forms.Button addButton;

        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.TextBox countryTB;
        private System.Windows.Forms.TextBox streetTB;
        private System.Windows.Forms.TextBox raceIdsTB;

        private System.Windows.Forms.TextBox cityTB;
        private System.Windows.Forms.TextBox postalCodeTB;

        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox emailTB;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}