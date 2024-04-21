using System.Drawing;
using System.Windows.Forms;
using AC4_M3UF5.Codes;
using AC4_M3UF5.DTOs;
using AC4_M3UF5.Persistence.DAO;
using AC4_M3UF5.Persistence.Mapping;
using AC4_M3UF5.Persistence.Utils;

namespace AC4_M3UF5
{
    public partial class managementForm : Form
    {
        private IRegionDAO regionDAO = new RegionDAO(NpgsqlUtils.OpenConnection());
        private List<Codes.Region> regionsCSV = FileHelper.ReadCSVFile("../../../Files/ConsumAiguesComarca.csv");

        public managementForm()
        {
            InitializeComponent();
        }

        private void managementForm_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> regionsKeyValue = new Dictionary<int, string>();

            InitializeKeyValueXML(ref regionsKeyValue);

            //comboYear:
            comboYear.Items.AddRange(QueryMethods.ListOfYears(regionsCSV));

            //comboRegion:
            comboRegion.DataSource = new BindingSource(regionsKeyValue, null);
            comboRegion.DisplayMember = "Value";
            comboRegion.ValueMember = "Key";
            comboRegion.SelectedIndex = -1;

            //dataGridRegions:
            InitializateDataGrid();

            //Database:
            regionDAO.CreateRegionDB();
        }

        private void InitializateDataGrid()
        {
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

        private void InitializeKeyValueXML(ref Dictionary<int, string> regionsKeyValue)
        {
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

        private bool IsRegionExistInCSV(int year, int code)
        {
            foreach (var region in regionsCSV)
            {
                if (region.Year == year && region.Code == code)
                {
                    return true;
                }
            }
            return false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string pathCSV = "../../../Files/ConsumAiguesComarca.csv";

            labelMessage.Text = "";
            labelMessage.ForeColor = Color.Red;

            if (ValidateChildren())
            {
                Codes.Region region = new Codes.Region
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

                if (!IsRegionExistInCSV(region.Year, region.Code))
                {
                    FileHelper.AddRegionToCSV(region, pathCSV);
                    this.regionsCSV = FileHelper.ReadCSVFile(pathCSV); //Actualitzem la llista de regions
                    InitializateDataGrid();

                    labelMessage.Text = "Region added to csv successfully";
                    labelMessage.ForeColor = Color.Green;
                }
                else
                {
                    labelMessage.Text = "Can't add region to csv, because the data \nalready exists";
                    labelMessage.ForeColor = Color.Red;
                }
            }
        }

        private void dataGridRegions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentCode = (int)dataGridRegions.CurrentRow.Cells[1].Value;
            int currentPopulation = (int)dataGridRegions.CurrentRow.Cells[3].Value;
            int currentDomesticConsum = (int)dataGridRegions.CurrentRow.Cells[4].Value;
            float currentConsumCapita = (float)dataGridRegions.CurrentRow.Cells[7].Value;

            List<Codes.Region> specificRegion = QueryMethods.GroupRegionByCode(regionsCSV, currentCode);

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
                labelMessage.Text += "Year can't be empty.";
                e.Cancel = true;
            }
            else if (!ComboYearList().Contains(comboYear.Text.Trim()))
            {
                errorYear.SetError(comboYear, "Year is not exist in the selections");
                labelMessage.Text += "Year is not exist in the selections.";
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
                labelMessage.Text += "Region can't be empty.\n";
                e.Cancel = true;
            }
            else if (!ComboRegionList().Contains(comboRegion.Text.Trim()))
            {
                errorRegion.SetError(comboRegion, "Region is not exist in the selections");
                labelMessage.Text += "Region is not exist in the selections.\n";
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
                labelMessage.Text += "Population can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textPopulation.Text, out int result))
            {
                errorPopulation.SetError(textPopulation, "Population must be a number");
                labelMessage.Text += "Population must be a number.\n";
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
                labelMessage.Text += "Domestic consumption can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textDomesticConsum.Text, out int result))
            {
                errorDomestic.SetError(textDomesticConsum, "Domestic consumption must be a number");
                labelMessage.Text += "Domestic consumption must be a number.\n";
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
                labelMessage.Text += "Economy consumption can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textEconomyConsum.Text, out int result))
            {
                errorEconomic.SetError(textEconomyConsum, "Economy consumption must be a number");
                labelMessage.Text += "Economy consumption must be a number.\n";
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
                labelMessage.Text += "Total consumption can't be empty.\n";
                e.Cancel = true;
            }
            else if (!int.TryParse(textTotalConsum.Text, out int result))
            {
                errorTotal.SetError(textTotalConsum, "Total consumption must be a number");
                labelMessage.Text += "Total consumption must be a number.\n";
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
                labelMessage.Text += "Consumption per capita can't be empty.\n";
                e.Cancel = true;
            }
            else if (!float.TryParse(textConsumCapita.Text, out float result))
            {
                errorCapita.SetError(textConsumCapita, "Consumption per capita must be a number");
                labelMessage.Text += "Consumption per capita must be a number.\n";
                e.Cancel = true;
            }
            else
            {
                errorCapita.SetError(textConsumCapita, null);
                e.Cancel = false;
            }
        }

        private void SaveRegionToDB(RegionDTO region)
        {
            if (regionDAO.GetRegionByCodeAndYear(region.Code, region.Year) == null)
            {
                regionDAO.InsertRegion(region);
                labelMessage.Text = "Region saved successfully in the database";
                labelMessage.ForeColor = Color.Green;
            }
            else
            {
                labelMessage.Text = "Region already exists in the database";
                labelMessage.ForeColor = Color.Red;
            }
        }

        private void buttonPersist_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            labelMessage.ForeColor = Color.Red;

            if (ValidateChildren())
            {
                RegionDTO region = new RegionDTO
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

                SaveRegionToDB(region);
            }
        }

        private void InsertCSVToDB()
        {
            int existFileCount = 0;
            int newFileCount = 0;
            foreach (var region in regionsCSV)
            {
                if (regionDAO.GetRegionByCodeAndYear(region.Code, region.Year) == null)
                {
                    RegionDTO regionDTO = new RegionDTO
                    {
                        Year = region.Year,
                        Code = region.Code,
                        Name = region.Name,
                        Population = region.Population,
                        DomesticConsum = region.DomesticConsum,
                        EconomyConsum = region.EconomyConsum,
                        TotalConsum = region.TotalConsum,
                        ConsumCapita = region.ConsumCapita
                    };
                    newFileCount++;
                    SaveRegionToDB(regionDTO);
                }
                else
                {
                    existFileCount++;
                }
            }
            labelMessage.Text = $"{existFileCount} regions already exist in the database." +
                                $"\n{newFileCount} regions imported to the database.";
            labelMessage.ForeColor = Color.Green;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "Loading, please wait...";
            labelMessage.ForeColor = Color.Red;
            Update(); //Muestra los mensajes antes de cargar los datos.
            InsertCSVToDB();
        }
    }
}
