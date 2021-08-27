using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GuildResources; //calling class library

namespace MSSAFirstProject
{
    /// <summary>
    /// Interaction logic for FourMvP.xaml
    /// </summary>
    public partial class FourMvP : UserControl
    {

        //Calling the class repository in classlibrary 
        GuildStorageRepository gsRepo;

        public FourMvP()
        {
            InitializeComponent();

            InitialDisplay();

            gsRepo = new GuildStorageRepository();
        }

        #region Initial Display 
        //Line 48. Display MvP Storage Grid
        private void btndispMvPStorage_Click(object sender, RoutedEventArgs e)
        {
            gridMvPStorageEdits.Visibility = Visibility.Visible; //make this visible
            hideViewsNAddsButtons(); //Hide View and Add Buttons

            //Need to call master storage
            ShowMasterStorage();
        }

        //Line 1280.  Go Back to Previous Screen
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            var Window = (MainWindow)Application.Current.MainWindow;
            Window.myControls.Content = new ThreeSelections();
        }

        #endregion


        #region VAUD
        //Line 83. View Item Buttons
        private void btnMvPViewItems_Click(object sender, RoutedEventArgs e)
        {
            gridMvPViews.Visibility = Visibility.Visible; //the grid becomes enabled
            dgMvPStorage.Visibility = Visibility.Visible; //the dg becomes enabled
            gridMvPAdds.Visibility = Visibility.Hidden; //hide Add New Buttons grid

            //Hide Add New Item Grids -- put in a method by itself
            gridMvPAddNewMisc.Visibility = Visibility.Hidden;
            gridMvPAddNewCons.Visibility = Visibility.Hidden;
            gridMvPAddNewAr.Visibility = Visibility.Hidden;
            gridMvPAddNewWpn.Visibility = Visibility.Hidden;
            gridMvPAddNewCard.Visibility = Visibility.Hidden;
        }


        //Line 103.  Display Add Buttons
        private void btnMvPAddItems_Click(object sender, RoutedEventArgs e)
        {
            gridMvPAdds.Visibility = Visibility.Visible; //Display Add Buttons Grid
            gridMvPViews.Visibility = Visibility.Hidden; //Hide View Buttons Grid
        }


        //Line 123.  Updating Items
        private void btnMvPUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Call information from Datagrid to update grid
            updateItem();
        }


        //Line 143.  Delete Item
        private void btnMvPDelete_Click(object sender, RoutedEventArgs e)
        {
            //Hide View and Add Buttons
            hideViewsNAddsButtons();

            //Select an Item from the datagrid and delete!
            deleteItem();

        }
        #endregion


        #region View Specific Item Buttons from Datagrid
        //Line 166.  View Consumables Only
        private void btnMvPViewCons_Click(object sender, RoutedEventArgs e)
        {
            //Display Consumables ONLY from DB to datagrid
            ShowConsOnly();
        }

        //Line 186. View Weapons ONLY
        private void btnMvPViewWpns_Click(object sender, RoutedEventArgs e)
        {
            //View Weapons only from DB to datagrid
            ShowWpnOnly();
        }

        //Line 206.  View Armors Only
        private void btnMvPViewArmos_Click(object sender, RoutedEventArgs e)
        {
            //Display Armors only from DB to datagrid
            ShowArmorsOnly();
        }

        //Line 226.  View Cards Only
        private void btnMvPViewCards_Click(object sender, RoutedEventArgs e)
        {
            //Display Cards only from DB to datagrid
            ShowCardsOnly();
        }

        //Line 246. View Miscellaneous Items ONLY
        private void btnMvPViewMisc_Click(object sender, RoutedEventArgs e)
        {
            //View Misc items only from DB to datagrid
            ShowMiscOnly();
        }




        #endregion


        #region Updating Item
        private void btnUpdItem_Click(object sender, RoutedEventArgs e)
        {
            addUpdatedItem();
        }

        private void btnExitUpd_Click(object sender, RoutedEventArgs e)
        {
            gridMvPUpDateItem.Visibility = Visibility.Hidden; //Hide Add New Consumable Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable Datagrid


            //enable buttons when exiting item is in progress
            enabledVAUD();

            //Clear textblocks after exit
            ClearCons();
        }
        #endregion


        #region Display and Add New Consumables
        //Line 268.  Display Add New Consumable Grid
        private void btnMvPAddCons_Click(object sender, RoutedEventArgs e)
        {
            dgMvPStorage.Visibility = Visibility.Hidden; //Hide datagrid
            gridMvPAddNewCons.Visibility = Visibility.Visible; //Enable Add New Cons Grid

            //Hide other 4
            gridMvPAddNewAr.Visibility = Visibility.Hidden;
            gridMvPAddNewWpn.Visibility = Visibility.Hidden;
            gridMvPAddNewCard.Visibility = Visibility.Hidden;
            gridMvPAddNewMisc.Visibility = Visibility.Hidden;

            //disable buttons when Adding item is in progress
            disabledVAUD();

            //Need to disable other 4 Add buttons
            disableAddButtons();

            //Show consumable only on grid
            ClearNewCons();
        }

        //Line 510. Adding New Consumable
        private void btnAddingItem_Click(object sender, RoutedEventArgs e)
        {
            addNewCons();
        }


        //Line 533 - Exit Adding Consumable
        private void btnExitAdd_Click(object sender, RoutedEventArgs e)
        {
            gridMvPAddNewCons.Visibility = Visibility.Hidden; //Hide Add New Armor Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable datagrid

            //enable buttons when exiting item is in progress
            enabledVAUD();
            enableAddButtons();

            
            //Clear textblocks after exit
            ClearCons();
        }

        #endregion


        #region Display and Add New Armors

        //Line 313.  Display Add New Armor Grid
        private void btnMvPAddArmos_Click(object sender, RoutedEventArgs e)
        {
            dgMvPStorage.Visibility = Visibility.Hidden; //Hide datagrid
            gridMvPAddNewAr.Visibility = Visibility.Visible; //Enable Add New Armor Grid

            //Hide all the other grids
            gridMvPAddNewCons.Visibility = Visibility.Hidden;
            gridMvPAddNewWpn.Visibility = Visibility.Hidden;
            gridMvPAddNewCard.Visibility = Visibility.Hidden;
            gridMvPAddNewMisc.Visibility = Visibility.Hidden;

            //disable buttons when Adding item is in progress
            disabledVAUD();


            //Need to hide other buttons
            disableAddButtons();

            //Clearing boxes and then call base on ID for new Item
            ClearNewArmor();
        }

        //Line 691 Adding New Armor
        private void btnAddingItemAr_Click(object sender, RoutedEventArgs e)
        {
            addNewArmor();
        }

        //Line 714 Exit Adding new Armor
        private void btnExitAddAr_Click(object sender, RoutedEventArgs e)
        {
            gridMvPAddNewAr.Visibility = Visibility.Hidden; //Hide Add New Armor Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable datagrid

            //enable buttons when exiting item is in progress
            enabledVAUD();

            //enable Add buttons upon exit
            enableAddButtons();

            //Clear txtblocks after exit
            ClearAmor();
        }

        #endregion


        #region Display and Add New Weapons

        //Line 291.  Populate Add New Weapon Grid
        private void btnMvPAddWpns_Click(object sender, RoutedEventArgs e)
        {
            dgMvPStorage.Visibility = Visibility.Hidden; //Hide Datagrid
            gridMvPAddNewWpn.Visibility = Visibility.Visible; //Populate Add New Weapon Grid

            //Hide all the other Grids
            gridMvPAddNewCons.Visibility = Visibility.Hidden;
            gridMvPAddNewAr.Visibility = Visibility.Hidden;
            gridMvPAddNewCard.Visibility = Visibility.Hidden;
            gridMvPAddNewMisc.Visibility = Visibility.Hidden;

            //disable buttons when Adding item is in progress
            disabledVAUD();

            //Need to Disable other 4 buttons from Add
            disableAddButtons();

            //Clear textboxes, call Id value
            ClearNewWpn();
        }
        //Line 878 Adding New Weapon
        private void btnAddingItemWpn_Click(object sender, RoutedEventArgs e)
        {
            addNewWeapon();
        }

        //Line 901. Exit Adding Weapon
        private void btnExitAddWpn_Click(object sender, RoutedEventArgs e)
        {
            gridMvPAddNewWpn.Visibility = Visibility.Hidden; //Hide Add New Weapon Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable datagrid

            //enable buttons when exiting item is in progress
            enabledVAUD();

            //enable Add Buttons upon exit
            enableAddButtons();

            //Clear txt blocks on exit
            ClearWpn();
        }
        #endregion


        #region Display and Add New Cards

        //Line 335.  Display Add New Card Grid
        private void btnMvPAddCards_Click(object sender, RoutedEventArgs e)
        {
            dgMvPStorage.Visibility = Visibility.Hidden; //Hide datagrid
            gridMvPAddNewCard.Visibility = Visibility.Visible; //Enable Add New Card Grid

            //Hide other 4
            gridMvPAddNewCons.Visibility = Visibility.Hidden;
            gridMvPAddNewAr.Visibility = Visibility.Hidden;
            gridMvPAddNewWpn.Visibility = Visibility.Hidden;
            gridMvPAddNewMisc.Visibility = Visibility.Hidden;

            //disable VAUD when Adding item is in progress
            disabledVAUD();

            //Disable add buttons
            disableAddButtons();

            //Clear textboxes then call Id Value
            ClearNewCard();
        }
        //Line 1053. Adding New Card
        private void btnAddingItemCard_Click(object sender, RoutedEventArgs e)
        {
            addNewCard();
        }

        //Line 1076.  Exit Adding New Card
        private void btnExitAddCard_Click(object sender, RoutedEventArgs e)
        {
            gridMvPAddNewCard.Visibility = Visibility.Hidden; //Hide Add New Card Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable datagrid

            //enable VAUD when exiting item is in progress
            enabledVAUD();

            //Enable Add Buttons upon exit
            enableAddButtons();

            //Clear txtblocks after exit
            ClearCard();
        }
        #endregion


        #region Display and Add New Miscellaneous

        //Line 357. Populate Adding Misc Grid
        private void btnMvPAddMisc_Click(object sender, RoutedEventArgs e)
        {
            //disabling and enabling grids
            dgMvPStorage.Visibility = Visibility.Hidden; //Disable datagrid
            gridMvPAddNewMisc.Visibility = Visibility.Visible; //Adding Misc Grid become visible when clicked on this button

            //the other 4 grids are hidden
            gridMvPAddNewCons.Visibility = Visibility.Hidden;
            gridMvPAddNewAr.Visibility = Visibility.Hidden;
            gridMvPAddNewWpn.Visibility = Visibility.Hidden;
            gridMvPAddNewCard.Visibility = Visibility.Hidden;

            //disable buttons when Adding item is in progress
            disabledVAUD();

            //disable Add Buttons when add in progress
            disableAddButtons();

            //Clear textboxes and call Id Value
            ClearNewMisc();

        }

        //Line 1228.  Add New Miscellaneous Item
        private void btnAddingItemMisc_Click(object sender, RoutedEventArgs e)
        {
            addNewMisc();
        }

        //Line 1251.  Exit Add New Miscellaneous Item Grid
        private void btnExitAddMisc_Click(object sender, RoutedEventArgs e)
        {
            gridMvPAddNewMisc.Visibility = Visibility.Hidden; //Hide this grid
            dgMvPStorage.Visibility = Visibility.Visible; //Display datagrid

            //enable buttons when exiting item is in progress
            enabledVAUD();

            //enable Add buttons upon exit
            enableAddButtons();

            //Clear Txtblocks after exit
            ClearMisc();

        }
        #endregion


        #region My Personal Methods

        //Create an sync event to delay display of buttons
        async void InitialDisplay()
        {
            await Task.Delay(5000);
            gridBackButton.Visibility = Visibility.Visible;
            btndispMvPStorage.Visibility = Visibility.Visible;
        }

        //Create a Method to display MvP Storage Only!
        private void ShowMasterStorage()
        {
            dgMvPStorage.ItemsSource = null;
            dgMvPStorage.ItemsSource = gsRepo.Query("Select*from dbo.GStorage Where GuildID = 1");

            //dgMvPStorage.ItemsSource = gsRepo.Read().Where(p => p.GuildID == 1);

            dgMvPStorage.Columns[5].Visibility = Visibility.Hidden;
        }

        //Create a method to disable VAUD buttons
        private void disabledVAUD()
        {
            btnMvPViewItems.IsEnabled = false;
            btnMvPAddItems.IsEnabled = false;
            btnMvPUpdate.IsEnabled = false;
            btnMvPDelete.IsEnabled = false;
        }

        //Create a method to enable VAUD buttons
        private void enabledVAUD()
        {
            btnMvPViewItems.IsEnabled = true;
            btnMvPAddItems.IsEnabled = true;
            btnMvPUpdate.IsEnabled = true;
            btnMvPDelete.IsEnabled = true;
        }

        //Create a method to disable Add Items Buttons
        private void disableAddButtons()
        {
            btnMvPAddCons.IsEnabled = false;
            btnMvPAddWpns.IsEnabled = false;
            btnMvPAddArmos.IsEnabled = false;
            btnMvPAddCards.IsEnabled = false;
            btnMvPAddMisc.IsEnabled = false;
        }

        //Create a method to enable Add Items Buttons
        private void enableAddButtons()
        {
            btnMvPAddCons.IsEnabled = true;
            btnMvPAddWpns.IsEnabled = true;
            btnMvPAddArmos.IsEnabled = true;
            btnMvPAddCards.IsEnabled = true;
            btnMvPAddMisc.IsEnabled = true;
        }

        //Create a method to hide the Views and Adds Buttons
        private void hideViewsNAddsButtons()
        {
            gridMvPViews.Visibility = Visibility.Hidden;
            gridMvPAdds.Visibility = Visibility.Hidden;
        }

        //Create a method to clear Add New Consumable Grid
        private void ClearCons()
        {
            txtBoxItemID.Clear();
            comBoxItemType.SelectedItem = null;
            comBoxItemType.SelectedItem = "Select Item";
            txtBoxItemDesc.Clear();
            txtBoxQty.Clear();
            txtBoxConsGuildID.Clear();
        }

        //Create a method to clear Add New Amor Grid
        private void ClearAmor()
        {
            txtBoxItemIDAr.Clear();
            comBoxItemTypeAr.SelectedItem = null;
            comBoxItemTypeAr.SelectedItem = "Select Armor";
            txtBoxItemDescAr.Clear();
            txtBoxQtyAr.Clear();
            txtBoxArGuildID.Clear();
        }

        //Create a method to clear Add New Weapon Grid
        private void ClearWpn()
        {
            txtBoxItemIDWpn.Clear();
            comBoxItemTypeWpn.SelectedItem = null;
            comBoxItemTypeWpn.SelectedItem = "Select Weapon";
            txtBoxItemDescWpn.Clear();
            txtBoxQtyWpn.Clear();
            txtBoxWpnGuildID.Clear();
        }

        //Create a method to clear Add New Card Grid
        private void ClearCard()
        {
            txtBoxItemIDCard.Clear();
            txtBoxItemTypeCard.Clear();
            txtBoxItemDescCard.Clear();
            txtBoxQtyCard.Clear();
            txtBoxCardGuildID.Clear();
        }

        //Create a method to clear Add New Misc Grid
        private void ClearMisc()
        {
            txtBoxItemIDMisc.Clear();
            txtBoxItemTypeMisc.Clear();
            txtBoxItemDescMisc.Clear();
            txtBoxQtyMisc.Clear();
            txtBoxMiscGuildID.Clear();
        }

        //Create a method to clear Update Grid
        private void ClearUpd()
        {
            txtBoxUpdID.Clear();
            txtBoxUpdType.Clear();
            txtBoxUpdDesc.Clear();
            txtBoxUpdQty.Clear();
            txtBoxUpdGuildID.Clear();
        }

        //Create a method to display Consumables Only
        private void ShowConsOnly()
        {
            dgMvPStorage.ItemsSource = null;
            dgMvPStorage.ItemsSource = gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 101 AND 500");
            dgMvPStorage.Columns[5].Visibility = Visibility.Hidden;
        }

        //Create a method to display Armor Only
        private void ShowArmorsOnly()
        {
            dgMvPStorage.ItemsSource = null;
            dgMvPStorage.ItemsSource = gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 1001 AND 1500");
            dgMvPStorage.Columns[5].Visibility = Visibility.Hidden;
        }

        //Create a method to display Weapon Only
        private void ShowWpnOnly()
        {
            dgMvPStorage.ItemsSource = null;
            dgMvPStorage.ItemsSource = gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 2001 AND 2500");
            dgMvPStorage.Columns[5].Visibility = Visibility.Hidden;
        }

        //Create a method to display Card Only
        private void ShowCardsOnly()
        {
            dgMvPStorage.ItemsSource = null;
            dgMvPStorage.ItemsSource = gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 3001 AND 3500");
            dgMvPStorage.Columns[5].Visibility = Visibility.Hidden;
        }

        //Create a method to display Misc Only
        private void ShowMiscOnly()
        {
            dgMvPStorage.ItemsSource = null;
            dgMvPStorage.ItemsSource = gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 4001 AND 4500");
            dgMvPStorage.Columns[5].Visibility = Visibility.Hidden;
        }

        //Create a method for Delete
        private void deleteItem()
        {
            var delItem = (GStorage)dgMvPStorage.SelectedItem;
            gsRepo.Delete(delItem);
            ShowMasterStorage();
        }

        //Create a method for Update
        private void updateItem()
        {
            //create a try catch block to make sure an item is selected, if not, a exception messagebox pop up
            try
            {
                GStorage upItem = (GStorage)dgMvPStorage.SelectedItem; //casting GStorage to select an item
                if (upItem is null)
                {
                    throw new Exception();
                }

                //Need to create a grid for Updating Items
                //display grid when clicked
                dgMvPStorage.Visibility = Visibility.Hidden; //Hide datagrid
                gridMvPUpDateItem.Visibility = Visibility.Visible;


                var updItem = gsRepo.Read().First(p => p.GSItemID == upItem.GSItemID); //need to find select item ID

                //now to bring up the information from the selected item
                txtBoxUpdID.Text = updItem.GSItemID.ToString(); //ItemID is ReadOnly
                txtBoxUpdType.Text = updItem.GSItemType.ToString();
                txtBoxUpdDesc.Text = updItem.GSItemDescription.ToString();
                txtBoxUpdQty.Text = updItem.Qty.ToString();

                //Hide View and Add Buttons
                hideViewsNAddsButtons();

                //disable VAUDs when updating in progress
                disabledVAUD();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please Select an Item");
                enabledVAUD();
            }
        }

        //Create method for button to updating item
        private void addUpdatedItem()
        {
            var id = Convert.ToDecimal(txtBoxUpdID.Text); //Getting information object GSItemID
            var updItem = gsRepo.GetInformation((decimal)id); //getting information from that ID, making the ID box readonly

            //Now to associate the db and the rest of the textboxes
            updItem.GSItemType = txtBoxUpdType.Text;
            updItem.GSItemDescription = txtBoxUpdDesc.Text;
            updItem.Qty = Convert.ToDecimal(txtBoxUpdQty.Text);
            updItem.GuildID = Convert.ToDecimal(txtBoxUpdGuildID.Text);

            //Now call the Update method from CRUD, update by selected ID, and update information
            gsRepo.Update((decimal)id, updItem);

            //Display message box the the item has been updated
            MessageBox.Show($"{txtBoxUpdType.Text} has been updated");
            //Clear textblocks after update
            ClearUpd();
            gridMvPUpDateItem.Visibility = Visibility.Hidden; //Hide Add New Consumable Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable Datagrid
            //enable buttons afterupdate
            enabledVAUD();

            //refresh Master Storage
            ShowMasterStorage();
        }

        //Create method to add new consumables
        private void addNewCons()
        {
            //Create an if loop to check if string is NOT null or whitespace
            if (!string.IsNullOrWhiteSpace(txtBoxItemID.Text) && !string.IsNullOrWhiteSpace(comBoxItemType.Text) && !string.IsNullOrWhiteSpace(txtBoxItemDesc.Text)
                && !string.IsNullOrWhiteSpace(txtBoxQty.Text) && !string.IsNullOrWhiteSpace(txtBoxConsGuildID.Text))
            {
                //call the DB get set
                GStorage obj = new GStorage();

                //align item with txtboxes
                obj.GSItemID = Convert.ToDecimal(txtBoxItemID.Text); //need to convert to decimal
                obj.GSItemType = comBoxItemType.Text;
                obj.GSItemDescription = txtBoxItemDesc.Text;
                obj.Qty = Convert.ToDecimal(txtBoxQty.Text);
                obj.GuildID = Convert.ToDecimal(txtBoxConsGuildID.Text);

                //now to call the Create method in crud to create the obj
                gsRepo.create(obj);

                //Display a message box showing item has been updated
                MessageBox.Show($"A new {comBoxItemType.Text} has been added");

                //Clear textblocks after update
                ClearCons();
            }

            gridMvPAddNewCons.Visibility = Visibility.Hidden; //Hide Add New Consumable Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable Datagrid
            //enable add buttons upon exit
            enableAddButtons();
            //enable buttons afterupdate
            enabledVAUD();
            //Refresh Grid after entry
            ShowMasterStorage();
        }

        //Create a method to clear Add New Cons boxes and adding GSItemID to +1 from highest number
        public void ClearNewCons()
        {
            txtBoxItemID.Clear();
            txtBoxItemID.IsReadOnly = true;
            txtBoxItemID.Text = (gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 101 AND 500").Max(p => p.GSItemID) + 1).ToString();
            comBoxItemType.SelectedItem = null;
            txtBoxItemDesc.Clear();
            txtBoxQty.Clear();
            txtBoxConsGuildID.Clear();
            txtBoxConsGuildID.Text = "1";
            txtBoxConsGuildID.IsReadOnly = true;
        }

        //Create method to add new armor
        private void addNewArmor()
        {
            //Create an if loop to check if string is NOT null or whitespace
            if (!string.IsNullOrWhiteSpace(txtBoxItemIDAr.Text) && !string.IsNullOrWhiteSpace(comBoxItemTypeAr.Text) && !string.IsNullOrWhiteSpace(txtBoxItemDescAr.Text)
                && !string.IsNullOrWhiteSpace(txtBoxQtyAr.Text) && !string.IsNullOrWhiteSpace(txtBoxArGuildID.Text))
            {
                //call the DB get set
                GStorage obj = new GStorage();

                //align item with txtboxes
                obj.GSItemID = Convert.ToDecimal(txtBoxItemIDAr.Text); //need to convert to decimal
                obj.GSItemType = comBoxItemTypeAr.Text;
                obj.GSItemDescription = txtBoxItemDescAr.Text;
                obj.Qty = Convert.ToDecimal(txtBoxQtyAr.Text);
                obj.GuildID = Convert.ToDecimal(txtBoxArGuildID.Text);

                //now to call the Create method in crud to create the obj
                gsRepo.create(obj);

                //Display a message box showing item has been updated
                MessageBox.Show($"A new {comBoxItemTypeAr.Text} has been added");

                //Clear textblocks after update
                ClearCons();
            }

            gridMvPAddNewAr.Visibility = Visibility.Hidden; //Hide Add New Consumable Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable Datagrid
            //enable add buttons upon exit
            enableAddButtons();
            //enable buttons afterupdate
            enabledVAUD();
            //Refresh Grid after entry
            ShowMasterStorage();
        }

        //Create a method to clear Add New Armor boxes and adding GSItemID to +1 from highest number
        public void ClearNewArmor()
        {
            txtBoxItemIDAr.Clear();
            txtBoxItemIDAr.IsReadOnly = true;
            txtBoxItemIDAr.Text = (gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 1001 AND 1500").Max(p => p.GSItemID) + 1).ToString();
            comBoxItemTypeAr.SelectedItem = null;
            txtBoxItemDescAr.Clear();
            txtBoxQtyAr.Clear();
            txtBoxArGuildID.Clear();
            txtBoxArGuildID.Text = "1";
            txtBoxArGuildID.IsReadOnly = true;
        }

        //Create method to add new weapon
        private void addNewWeapon()
        {
            //Create an if loop to check if string is NOT null or whitespace
            if (!string.IsNullOrWhiteSpace(txtBoxItemIDWpn.Text) && !string.IsNullOrWhiteSpace(comBoxItemTypeWpn.Text) && !string.IsNullOrWhiteSpace(txtBoxItemDescWpn.Text)
                && !string.IsNullOrWhiteSpace(txtBoxQtyWpn.Text) && !string.IsNullOrWhiteSpace(txtBoxWpnGuildID.Text))
            {
                //call the DB get set
                GStorage obj = new GStorage();

                //align item with txtboxes
                obj.GSItemID = Convert.ToDecimal(txtBoxItemIDWpn.Text); //need to convert to decimal
                obj.GSItemType = comBoxItemTypeWpn.Text;
                obj.GSItemDescription = txtBoxItemDescWpn.Text;
                obj.Qty = Convert.ToDecimal(txtBoxQtyWpn.Text);
                obj.GuildID = Convert.ToDecimal(txtBoxWpnGuildID.Text);

                //now to call the Create method in crud to create the obj
                gsRepo.create(obj);

                //Display a message box showing item has been updated
                MessageBox.Show($"A new {comBoxItemTypeWpn.Text} has been added");

                //Clear textblocks after update
                ClearCons();
            }

            gridMvPAddNewWpn.Visibility = Visibility.Hidden; //Hide Add New Consumable Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable Datagrid
            //enable add buttons upon exit
            enableAddButtons();
            //enable buttons afterupdate
            enabledVAUD();
            //Refresh Grid after entry
            ShowMasterStorage();
        }

        //Create a method to clear Add New Armor boxes and adding GSItemID to +1 from highest number
        public void ClearNewWpn()
        {
            txtBoxItemIDWpn.Clear();
            txtBoxItemIDWpn.IsReadOnly = true;
            txtBoxItemIDWpn.Text = (gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 2001 AND 2500").Max(p => p.GSItemID) + 1).ToString();
            comBoxItemTypeWpn.SelectedItem = null;
            txtBoxItemDescWpn.Clear();
            txtBoxQtyWpn.Clear();
            txtBoxWpnGuildID.Clear();
            txtBoxWpnGuildID.Text = "1";
            txtBoxWpnGuildID.IsReadOnly = true;
        }

        //Create method to add new Card
        private void addNewCard()
        {
            //Create an if loop to check if string is NOT null or whitespace
            if (!string.IsNullOrWhiteSpace(txtBoxItemIDCard.Text) && !string.IsNullOrWhiteSpace(txtBoxItemTypeCard.Text) && !string.IsNullOrWhiteSpace(txtBoxItemDescCard.Text)
                && !string.IsNullOrWhiteSpace(txtBoxQtyCard.Text) && !string.IsNullOrWhiteSpace(txtBoxCardGuildID.Text))
            {
                //call the DB get set
                GStorage obj = new GStorage();

                //align item with txtboxes
                obj.GSItemID = Convert.ToDecimal(txtBoxItemIDCard.Text); //need to convert to decimal
                obj.GSItemType = txtBoxItemTypeCard.Text;
                obj.GSItemDescription = txtBoxItemDescCard.Text;
                obj.Qty = Convert.ToDecimal(txtBoxQtyCard.Text);
                obj.GuildID = Convert.ToDecimal(txtBoxCardGuildID.Text);

                //now to call the Create method in crud to create the obj
                gsRepo.create(obj);

                //Display a message box showing item has been updated
                MessageBox.Show($"A new {txtBoxItemTypeCard.Text} has been added");

                //Clear textblocks after update
                ClearCons();
            }

            gridMvPAddNewCard.Visibility = Visibility.Hidden; //Hide Add New Consumable Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable Datagrid
            //enable add buttons upon exit
            enableAddButtons();
            //enable buttons afterupdate
            enabledVAUD();
            //Refresh Grid after entry
            ShowMasterStorage();
        }

        //Create a method to clear Add New Card boxes and adding GSItemID to +1 from highest number
        public void ClearNewCard()
        {
            txtBoxItemIDCard.Clear();
            txtBoxItemIDCard.IsReadOnly = true;
            txtBoxItemIDCard.Text = (gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 3001 AND 3500").Max(p => p.GSItemID) + 1).ToString();
            txtBoxItemTypeCard.Text = "Card";
            txtBoxItemDescCard.Clear();
            txtBoxQtyCard.Clear();
            txtBoxCardGuildID.Clear();
            txtBoxCardGuildID.Text = "1";
            txtBoxCardGuildID.IsReadOnly = true;
        }

        //Create method to add new Misc
        private void addNewMisc()
        {
            //Create an if loop to check if string is NOT null or whitespace
            if (!string.IsNullOrWhiteSpace(txtBoxItemIDMisc.Text) && !string.IsNullOrWhiteSpace(txtBoxItemTypeMisc.Text) && !string.IsNullOrWhiteSpace(txtBoxItemDescMisc.Text)
                && !string.IsNullOrWhiteSpace(txtBoxQtyMisc.Text) && !string.IsNullOrWhiteSpace(txtBoxMiscGuildID.Text))
            {
                //call the DB get set
                GStorage obj = new GStorage();

                //align item with txtboxes
                obj.GSItemID = Convert.ToDecimal(txtBoxItemIDMisc.Text); //need to convert to decimal
                obj.GSItemType = txtBoxItemTypeMisc.Text;
                obj.GSItemDescription = txtBoxItemDescMisc.Text;
                obj.Qty = Convert.ToDecimal(txtBoxQtyMisc.Text);
                obj.GuildID = Convert.ToDecimal(txtBoxMiscGuildID.Text);

                //now to call the Create method in crud to create the obj
                gsRepo.create(obj);

                //Display a message box showing item has been updated
                MessageBox.Show($"A new {txtBoxItemTypeMisc.Text} has been added");

                //Clear textblocks after update
                ClearCons();
            }

            gridMvPAddNewMisc.Visibility = Visibility.Hidden; //Hide Add New Consumable Grid
            dgMvPStorage.Visibility = Visibility.Visible; //Enable Datagrid
            //enable add buttons upon exit
            enableAddButtons();
            //enable buttons afterupdate
            enabledVAUD();
            //Refresh Grid after entry
            ShowMasterStorage();
        }

        //Create a method to clear Add New Misc boxes and adding GSItemID to +1 from highest number
        public void ClearNewMisc()
        {
            txtBoxItemIDMisc.Clear();
            txtBoxItemIDMisc.IsReadOnly = true;
            txtBoxItemIDMisc.Text = (gsRepo.Query("Select*From dbo.GStorage Where GSItemID Between 4001 AND 4500").Max(p => p.GSItemID) + 1).ToString();
            txtBoxItemTypeMisc.Text = "Misc";
            txtBoxItemDescMisc.Clear();
            txtBoxQtyMisc.Clear();
            txtBoxMiscGuildID.Clear();
            txtBoxMiscGuildID.Text = "1";
            txtBoxMiscGuildID.IsReadOnly = true;
        }

        #endregion



    }
}
