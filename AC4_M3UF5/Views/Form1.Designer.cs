using System;
using AC4_M3UF5.Codes;

namespace AC4_M3UF5
{
    partial class managementForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupManagement = new GroupBox();
            textConsumCapita = new TextBox();
            textTotalConsum = new TextBox();
            textEconomyConsum = new TextBox();
            textDomesticConsum = new TextBox();
            textPopulation = new TextBox();
            labelConsumCapita = new Label();
            labelTotalConsum = new Label();
            labelEconomyConsum = new Label();
            labelDomesticConsum = new Label();
            comboRegion = new ComboBox();
            comboYear = new ComboBox();
            labelPopulation = new Label();
            labelRegion = new Label();
            labelYear = new Label();
            groupStats = new GroupBox();
            labelResStatFour = new Label();
            labelResStatThree = new Label();
            labelResStatTwo = new Label();
            labelResStatOne = new Label();
            labelFour = new Label();
            labelStatThree = new Label();
            labelStatTwo = new Label();
            labelStatOne = new Label();
            buttonClean = new Button();
            buttonSave = new Button();
            dataGridRegions = new DataGridView();
            errorYear = new ErrorProvider(components);
            errorRegion = new ErrorProvider(components);
            errorPopulation = new ErrorProvider(components);
            errorDomestic = new ErrorProvider(components);
            errorEconomic = new ErrorProvider(components);
            errorTotal = new ErrorProvider(components);
            errorCapita = new ErrorProvider(components);
            groupError = new GroupBox();
            labelErrorMessage = new Label();
            groupManagement.SuspendLayout();
            groupStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridRegions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorRegion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorPopulation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorDomestic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorEconomic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorCapita).BeginInit();
            groupError.SuspendLayout();
            SuspendLayout();
            // 
            // groupManagement
            // 
            groupManagement.Controls.Add(textConsumCapita);
            groupManagement.Controls.Add(textTotalConsum);
            groupManagement.Controls.Add(textEconomyConsum);
            groupManagement.Controls.Add(textDomesticConsum);
            groupManagement.Controls.Add(textPopulation);
            groupManagement.Controls.Add(labelConsumCapita);
            groupManagement.Controls.Add(labelTotalConsum);
            groupManagement.Controls.Add(labelEconomyConsum);
            groupManagement.Controls.Add(labelDomesticConsum);
            groupManagement.Controls.Add(comboRegion);
            groupManagement.Controls.Add(comboYear);
            groupManagement.Controls.Add(labelPopulation);
            groupManagement.Controls.Add(labelRegion);
            groupManagement.Controls.Add(labelYear);
            groupManagement.Location = new Point(26, 25);
            groupManagement.Name = "groupManagement";
            groupManagement.Size = new Size(398, 232);
            groupManagement.TabIndex = 0;
            groupManagement.TabStop = false;
            groupManagement.Text = "Region demographic data management";
            // 
            // textConsumCapita
            // 
            textConsumCapita.Location = new Point(285, 183);
            textConsumCapita.Name = "textConsumCapita";
            textConsumCapita.Size = new Size(79, 23);
            textConsumCapita.TabIndex = 14;
            textConsumCapita.Validating += textConsumCapita_Validating;
            // 
            // textTotalConsum
            // 
            textTotalConsum.Location = new Point(285, 154);
            textTotalConsum.Name = "textTotalConsum";
            textTotalConsum.Size = new Size(79, 23);
            textTotalConsum.TabIndex = 13;
            textTotalConsum.Validating += textTotalConsum_Validating;
            // 
            // textEconomyConsum
            // 
            textEconomyConsum.Location = new Point(285, 123);
            textEconomyConsum.Name = "textEconomyConsum";
            textEconomyConsum.Size = new Size(79, 23);
            textEconomyConsum.TabIndex = 12;
            textEconomyConsum.Validating += textEconomyConsum_Validating;
            // 
            // textDomesticConsum
            // 
            textDomesticConsum.Location = new Point(285, 94);
            textDomesticConsum.Name = "textDomesticConsum";
            textDomesticConsum.Size = new Size(79, 23);
            textDomesticConsum.TabIndex = 11;
            textDomesticConsum.Validating += textDomesticConsum_Validating;
            // 
            // textPopulation
            // 
            textPopulation.Location = new Point(285, 56);
            textPopulation.Name = "textPopulation";
            textPopulation.Size = new Size(79, 23);
            textPopulation.TabIndex = 10;
            textPopulation.Validating += textPopulation_Validating;
            // 
            // labelConsumCapita
            // 
            labelConsumCapita.AutoSize = true;
            labelConsumCapita.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelConsumCapita.Location = new Point(73, 186);
            labelConsumCapita.Name = "labelConsumCapita";
            labelConsumCapita.Size = new Size(193, 15);
            labelConsumCapita.TabIndex = 9;
            labelConsumCapita.Text = "Domestic consumption per capita";
            // 
            // labelTotalConsum
            // 
            labelTotalConsum.AutoSize = true;
            labelTotalConsum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTotalConsum.Location = new Point(232, 157);
            labelTotalConsum.Name = "labelTotalConsum";
            labelTotalConsum.Size = new Size(34, 15);
            labelTotalConsum.TabIndex = 8;
            labelTotalConsum.Text = "Total";
            // 
            // labelEconomyConsum
            // 
            labelEconomyConsum.AutoSize = true;
            labelEconomyConsum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEconomyConsum.Location = new Point(58, 126);
            labelEconomyConsum.Name = "labelEconomyConsum";
            labelEconomyConsum.Size = new Size(208, 15);
            labelEconomyConsum.TabIndex = 7;
            labelEconomyConsum.Text = "Economic activities and own sources";
            // 
            // labelDomesticConsum
            // 
            labelDomesticConsum.AutoSize = true;
            labelDomesticConsum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDomesticConsum.Location = new Point(155, 97);
            labelDomesticConsum.Name = "labelDomesticConsum";
            labelDomesticConsum.Size = new Size(111, 15);
            labelDomesticConsum.TabIndex = 6;
            labelDomesticConsum.Text = "Domestic network";
            // 
            // comboRegion
            // 
            comboRegion.FormattingEnabled = true;
            comboRegion.Location = new Point(108, 56);
            comboRegion.Name = "comboRegion";
            comboRegion.Size = new Size(158, 23);
            comboRegion.TabIndex = 4;
            comboRegion.Validating += comboRegion_Validating;
            // 
            // comboYear
            // 
            comboYear.FormattingEnabled = true;
            comboYear.Location = new Point(21, 56);
            comboYear.Name = "comboYear";
            comboYear.Size = new Size(64, 23);
            comboYear.TabIndex = 3;
            comboYear.Validating += comboYear_Validating;
            // 
            // labelPopulation
            // 
            labelPopulation.AutoSize = true;
            labelPopulation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPopulation.Location = new Point(285, 38);
            labelPopulation.Name = "labelPopulation";
            labelPopulation.Size = new Size(66, 15);
            labelPopulation.TabIndex = 2;
            labelPopulation.Text = "Population";
            // 
            // labelRegion
            // 
            labelRegion.AutoSize = true;
            labelRegion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelRegion.Location = new Point(108, 38);
            labelRegion.Name = "labelRegion";
            labelRegion.Size = new Size(46, 15);
            labelRegion.TabIndex = 1;
            labelRegion.Text = "Region";
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.BackColor = SystemColors.Control;
            labelYear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelYear.Location = new Point(21, 38);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(31, 15);
            labelYear.TabIndex = 0;
            labelYear.Text = "Year";
            // 
            // groupStats
            // 
            groupStats.Controls.Add(labelResStatFour);
            groupStats.Controls.Add(labelResStatThree);
            groupStats.Controls.Add(labelResStatTwo);
            groupStats.Controls.Add(labelResStatOne);
            groupStats.Controls.Add(labelFour);
            groupStats.Controls.Add(labelStatThree);
            groupStats.Controls.Add(labelStatTwo);
            groupStats.Controls.Add(labelStatOne);
            groupStats.Location = new Point(440, 25);
            groupStats.Name = "groupStats";
            groupStats.Size = new Size(352, 141);
            groupStats.TabIndex = 1;
            groupStats.TabStop = false;
            groupStats.Text = "Region statistics";
            // 
            // labelResStatFour
            // 
            labelResStatFour.AutoSize = true;
            labelResStatFour.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelResStatFour.ForeColor = Color.Blue;
            labelResStatFour.Location = new Point(280, 108);
            labelResStatFour.Name = "labelResStatFour";
            labelResStatFour.Size = new Size(12, 15);
            labelResStatFour.TabIndex = 21;
            labelResStatFour.Text = "-";
            // 
            // labelResStatThree
            // 
            labelResStatThree.AutoSize = true;
            labelResStatThree.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelResStatThree.ForeColor = Color.Blue;
            labelResStatThree.Location = new Point(280, 79);
            labelResStatThree.Name = "labelResStatThree";
            labelResStatThree.Size = new Size(12, 15);
            labelResStatThree.TabIndex = 20;
            labelResStatThree.Text = "-";
            // 
            // labelResStatTwo
            // 
            labelResStatTwo.AutoSize = true;
            labelResStatTwo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelResStatTwo.ForeColor = Color.Blue;
            labelResStatTwo.Location = new Point(280, 49);
            labelResStatTwo.Name = "labelResStatTwo";
            labelResStatTwo.Size = new Size(12, 15);
            labelResStatTwo.TabIndex = 19;
            labelResStatTwo.Text = "-";
            // 
            // labelResStatOne
            // 
            labelResStatOne.AutoSize = true;
            labelResStatOne.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelResStatOne.ForeColor = Color.Blue;
            labelResStatOne.Location = new Point(280, 23);
            labelResStatOne.Name = "labelResStatOne";
            labelResStatOne.Size = new Size(12, 15);
            labelResStatOne.TabIndex = 16;
            labelResStatOne.Text = "-";
            // 
            // labelFour
            // 
            labelFour.AutoSize = true;
            labelFour.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFour.Location = new Point(22, 108);
            labelFour.Name = "labelFour";
            labelFour.Size = new Size(232, 15);
            labelFour.TabIndex = 18;
            labelFour.Text = "Lower domestic consumption per capita:";
            // 
            // labelStatThree
            // 
            labelStatThree.AutoSize = true;
            labelStatThree.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStatThree.Location = new Point(19, 79);
            labelStatThree.Name = "labelStatThree";
            labelStatThree.Size = new Size(235, 15);
            labelStatThree.TabIndex = 17;
            labelStatThree.Text = "Higher domestic consumption per capita:";
            // 
            // labelStatTwo
            // 
            labelStatTwo.AutoSize = true;
            labelStatTwo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStatTwo.Location = new Point(65, 49);
            labelStatTwo.Name = "labelStatTwo";
            labelStatTwo.Size = new Size(189, 15);
            labelStatTwo.TabIndex = 16;
            labelStatTwo.Text = "Average Domestic Consumption:";
            // 
            // labelStatOne
            // 
            labelStatOne.AutoSize = true;
            labelStatOne.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStatOne.Location = new Point(110, 23);
            labelStatOne.Name = "labelStatOne";
            labelStatOne.Size = new Size(144, 15);
            labelStatOne.TabIndex = 15;
            labelStatOne.Text = "Population > 20000 hab.:";
            // 
            // buttonClean
            // 
            buttonClean.Location = new Point(217, 263);
            buttonClean.Name = "buttonClean";
            buttonClean.Size = new Size(95, 33);
            buttonClean.TabIndex = 2;
            buttonClean.Text = "Clean";
            buttonClean.UseVisualStyleBackColor = true;
            buttonClean.Click += buttonClean_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(329, 263);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(95, 33);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // dataGridRegions
            // 
            dataGridRegions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridRegions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridRegions.Location = new Point(26, 311);
            dataGridRegions.Name = "dataGridRegions";
            dataGridRegions.Size = new Size(766, 171);
            dataGridRegions.TabIndex = 4;
            dataGridRegions.CellClick += dataGridRegions_CellClick;
            // 
            // errorYear
            // 
            errorYear.ContainerControl = this;
            // 
            // errorRegion
            // 
            errorRegion.ContainerControl = this;
            // 
            // errorPopulation
            // 
            errorPopulation.ContainerControl = this;
            // 
            // errorDomestic
            // 
            errorDomestic.ContainerControl = this;
            // 
            // errorEconomic
            // 
            errorEconomic.ContainerControl = this;
            // 
            // errorTotal
            // 
            errorTotal.ContainerControl = this;
            // 
            // errorCapita
            // 
            errorCapita.ContainerControl = this;
            // 
            // groupError
            // 
            groupError.Controls.Add(labelErrorMessage);
            groupError.Location = new Point(440, 172);
            groupError.Name = "groupError";
            groupError.Size = new Size(352, 124);
            groupError.TabIndex = 5;
            groupError.TabStop = false;
            groupError.Text = "Inputs Error";
            // 
            // labelErrorMessage
            // 
            labelErrorMessage.AutoSize = true;
            labelErrorMessage.BackColor = SystemColors.Control;
            labelErrorMessage.ForeColor = Color.Red;
            labelErrorMessage.Location = new Point(53, 19);
            labelErrorMessage.Name = "labelErrorMessage";
            labelErrorMessage.Size = new Size(0, 15);
            labelErrorMessage.TabIndex = 0;
            // 
            // managementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(817, 494);
            Controls.Add(groupError);
            Controls.Add(dataGridRegions);
            Controls.Add(buttonSave);
            Controls.Add(buttonClean);
            Controls.Add(groupStats);
            Controls.Add(groupManagement);
            Name = "managementForm";
            Text = "Region demographic data management";
            Load += managementForm_Load;
            groupManagement.ResumeLayout(false);
            groupManagement.PerformLayout();
            groupStats.ResumeLayout(false);
            groupStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridRegions).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorRegion).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorPopulation).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorDomestic).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorEconomic).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorCapita).EndInit();
            groupError.ResumeLayout(false);
            groupError.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupManagement;
        private GroupBox groupStats;
        private Label labelPopulation;
        private Label labelRegion;
        private Label labelYear;
        private Label labelDomesticConsum;
        private ComboBox comboRegion;
        private ComboBox comboYear;
        private Label labelEconomyConsum;
        private Label labelTotalConsum;
        private Label labelConsumCapita;
        private TextBox textConsumCapita;
        private TextBox textTotalConsum;
        private TextBox textEconomyConsum;
        private TextBox textDomesticConsum;
        private TextBox textPopulation;
        private Button buttonClean;
        private Label labelStatThree;
        private Label labelStatTwo;
        private Label labelStatOne;
        private Button buttonSave;
        private Label labelResStatThree;
        private Label labelResStatTwo;
        private Label labelResStatOne;
        private Label labelFour;
        private Label labelResStatFour;
        private DataGridView dataGridRegions;
        private ErrorProvider errorYear;
        private ErrorProvider errorRegion;
        private ErrorProvider errorPopulation;
        private ErrorProvider errorDomestic;
        private ErrorProvider errorEconomic;
        private ErrorProvider errorTotal;
        private ErrorProvider errorCapita;
        private GroupBox groupError;
        private Label labelErrorMessage;
    }
}
