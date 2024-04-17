using System.Windows.Forms;
using AC3_M3UF5.CodeAC2;

namespace AC3_M3UF5
{
    public partial class managementForm : Form
    {
        public managementForm()
        {
            InitializeComponent();
        }

        private void managementForm_Load(object sender, EventArgs e)
        {
            List<CodeAC2.Region> regionsCSV = new List<CodeAC2.Region>();
            Dictionary<int, string> regionsKeyValue = new Dictionary<int, string>();

            InitializeVariables(ref regionsCSV, ref regionsKeyValue);

            //comboYear:
            comboYear.Items.AddRange(QueryMethods.ListOfYears(regionsCSV));

            //comboRegion:
            comboRegion.DataSource = new BindingSource(regionsKeyValue, null);
            comboRegion.DisplayMember = "Value";
            comboRegion.ValueMember = "Key";
            comboRegion.SelectedIndex = -1;

            //dataGridRegions:
            InitializateDataGrid();

        }

        private void InitializateDataGrid()
        {
            string pathCSV = "../../../Files/ConsumAiguesComarca.csv";
            List<CodeAC2.Region> regionsCSV = FileHelper.ReadCSVFile(pathCSV);

            dataGridRegions.DataSource = regionsCSV;
            dataGridRegions.Columns[0].HeaderText = "Year";
            dataGridRegions.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridRegions.Columns[1].Visible = false;
            dataGridRegions.Columns[2].HeaderText = "Region";
            dataGridRegions.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridRegions.Columns[3].HeaderText = "Population";
            dataGridRegions.Columns[4].HeaderText = "Domestic network";
            dataGridRegions.Columns[5].HeaderText = "Economic activities and own sources";
            dataGridRegions.Columns[6].HeaderText = "Total";
            dataGridRegions.Columns[7].HeaderText = "Domestic consumption per capita";
        }

        private void InitializeVariables(ref List<CodeAC2.Region> regionsCSV, ref Dictionary<int, string> regionsKeyValue)
        {
            //
            // Execute CSV file
            // 
            string pathCSV = "../../../Files/ConsumAiguesComarca.csv";
            regionsCSV = FileHelper.ReadCSVFile(pathCSV);
            //
            // Save XML File
            //
            string pathXML = "../../../Files/ConsumAiguesComarca_KeyValue.xml";
            if (!File.Exists(pathXML))
            {
                foreach (var region in regionsCSV)
                {
                    if (File.Exists(pathXML))
                    {
                        FileHelper.AddKeyValueXML(region, pathXML);
                    }
                    else
                    {
                        FileHelper.CreateKeyValueXML(region, pathXML);
                    }
                }
            }
            //
            // Execute XML file
            //
            regionsKeyValue = FileHelper.ReadKeyValueXML(pathXML);
        }

        private void CleanInputs()
        {
            comboYear.Text = "";
            comboRegion.Text = "";
            textPopulation.Text = "";
            textDomesticConsum.Text = "";
            textEconomyConsum.Text = "";
            textTotalConsum.Text = "";
            textConsumCapita.Text = "";
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            CleanInputs();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string pathCSV = "../../../Files/ConsumAiguesComarca.csv";

            labelErrorMessage.Text = "";

            if (ValidateChildren())
            {
                CodeAC2.Region region = new CodeAC2.Region
                {
                    Year = int.Parse(comboYear.Text),
                    Code = (int?)comboRegion.SelectedValue ?? 0,
                    Name = comboRegion.Text,
                    Population = int.Parse(textPopulation.Text),
                    DomesticConsum = int.Parse(textDomesticConsum.Text),
                    EconomyConsum = int.Parse(textEconomyConsum.Text),
                    TotalConsum = int.Parse(textTotalConsum.Text),
                    ConsumCapita = float.Parse(textConsumCapita.Text)
                };

                FileHelper.AddRegionToCSV(region, pathCSV);
                CleanInputs();
                InitializateDataGrid();
            }
        }

        private void dataGridRegions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentCode = (int)dataGridRegions.CurrentRow.Cells[1].Value;
            int currentPopulation = (int)dataGridRegions.CurrentRow.Cells[3].Value;
            int currentDomesticConsum = (int)dataGridRegions.CurrentRow.Cells[4].Value;
            float currentConsumCapita = (float)dataGridRegions.CurrentRow.Cells[7].Value;

            string pathCSV = "../../../Files/ConsumAiguesComarca.csv";
            List<CodeAC2.Region> allRegions = FileHelper.ReadCSVFile(pathCSV);
            List<CodeAC2.Region> specificRegion = QueryMethods.GroupRegionByCode(allRegions, currentCode);

            labelResStatOne.Text = QueryMethods.IsPopulationHigherThan20000(currentPopulation) ? "YES" : "NO";
            labelResStatTwo.Text = QueryMethods.AverageDomesticConsum(currentPopulation, currentDomesticConsum).ToString();
            labelResStatThree.Text = QueryMethods.IsHighestConsumCapita(specificRegion, currentConsumCapita) ? "YES" : "NO";
            labelResStatFour.Text = QueryMethods.IsLowestConsumCapita(specificRegion, currentConsumCapita) ? "YES" : "NO";
        }

        private List<string> ComboYearList()
        {
            List<string> list = new List<string>();
            foreach (var item in comboYear.Items)
            {
                list.Add(item.ToString() ?? "");
            }
            return list;
        }

        private List<string> ComboRegionList()
        {
            List<string> list = new List<string>();
            foreach (var item in comboRegion.Items)
            {
                /* Aportat per Copilot:
                 * Convertim "item" a un objecte per poder accedir a la propietat "Value" i obtenir 
                 * el valor de la regió. Després el convertim a string i l'afegim a la llista.
                 */
                string? Value = item.GetType().GetProperty("Value")?.GetValue(item)?.ToString();
                list.Add(Value ?? "");

            }
            return list;
        }


        private void comboYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboYear.Text))
            {
                errorYear.SetError(comboYear, "Year can't be empty");
                labelErrorMessage.Text += "Year can't be empty.";
                e.Cancel = true;
            }
            else if (!ComboYearList().Contains(comboYear.Text.Trim()))
            {
                errorYear.SetError(comboYear, "Year is not exist in the selections");
                labelErrorMessage.Text += "Year is not exist in the selections.";
                e.Cancel = true;
            }
            else
            {
                errorYear.SetError(comboYear, null);
                e.Cancel = false;
            }
        }

        private void comboRegion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboRegion.Text))
            {
                errorRegion.SetError(comboRegion, "Region can't be empty");
                labelErrorMessage.Text += "Region can't be empty.\n";
                e.Cancel = true;
            }
            else if (!ComboRegionList().Contains(comboRegion.Text.Trim()))
            {
                errorRegion.SetError(comboRegion, "Region is not exist in the selections");
                labelErrorMessage.Text += "Region is not exist in the selections.\n";
                e.Cancel = true;
            }
            else
            {
                errorRegion.SetError(comboRegion, null);
                e.Cancel = false;
            }
        }

        private void textPopulation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textPopulation.Text))
            {
                errorPopulation.SetError(textPopulation, "Population can't be empty");
                labelErrorMessage.Text += "Population can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textPopulation.Text, out int result))
            {
                errorPopulation.SetError(textPopulation, "Population must be a number");
                labelErrorMessage.Text += "Population must be a number.\n";
                e.Cancel = true;
            }
            else
            {
                errorPopulation.SetError(textPopulation, null);
                e.Cancel = false;
            }
        }

        private void textDomesticConsum_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textDomesticConsum.Text))
            {
                errorDomestic.SetError(textDomesticConsum, "Domestic consumption can't be empty");
                labelErrorMessage.Text += "Domestic consumption can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textDomesticConsum.Text, out int result))
            {
                errorDomestic.SetError(textDomesticConsum, "Domestic consumption must be a number");
                labelErrorMessage.Text += "Domestic consumption must be a number.\n";
                e.Cancel = true;
            }
            else
            {
                errorDomestic.SetError(textDomesticConsum, null);
                e.Cancel = false;
            }
        }

        private void textEconomyConsum_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textEconomyConsum.Text))
            {
                errorEconomic.SetError(textEconomyConsum, "Economy consumption can't be empty");
                labelErrorMessage.Text += "Economy consumption can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textEconomyConsum.Text, out int result))
            {
                errorEconomic.SetError(textEconomyConsum, "Economy consumption must be a number");
                labelErrorMessage.Text += "Economy consumption must be a number.\n";
                e.Cancel = true;
            }
            else
            {
                errorEconomic.SetError(textEconomyConsum, null);
                e.Cancel = false;
            }
        }

        private void textTotalConsum_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textTotalConsum.Text))
            {
                errorTotal.SetError(textTotalConsum, "Total consumption can't be empty");
                labelErrorMessage.Text += "Total consumption can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textTotalConsum.Text, out int result))
            {
                errorTotal.SetError(textTotalConsum, "Total consumption must be a number");
                labelErrorMessage.Text += "Total consumption must be a number.\n";
                e.Cancel = true;
            }
            else
            {
                errorTotal.SetError(textTotalConsum, null);
                e.Cancel = false;
            }
        }

        private void textConsumCapita_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textConsumCapita.Text))
            {
                errorCapita.SetError(textConsumCapita, "Consumption per capita can't be empty");
                labelErrorMessage.Text += "Consumption per capita can't be empty.\n";
                e.Cancel = true;
            }
            else if (!float.TryParse(textConsumCapita.Text, out float result))
            {
                errorCapita.SetError(textConsumCapita, "Consumption per capita must be a number");
                labelErrorMessage.Text += "Consumption per capita must be a number.\n";
                e.Cancel = true;
            }
            else
            {
                errorCapita.SetError(textConsumCapita, null);
                e.Cancel = false;
            }
        }
    }
}
