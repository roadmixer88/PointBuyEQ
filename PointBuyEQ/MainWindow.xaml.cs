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
using Xceed.Wpf.Toolkit;

namespace PointBuyEQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool process = true;
        private void Spinner_ValueChanged(object senderObj, RoutedPropertyChangedEventArgs<object> e)
        {
            if (!process)
            {
                process = true;
                return;
            }
            IntegerUpDown sender = (IntegerUpDown)senderObj;

            int oldValue = (e.OldValue==null) ? (int)e.NewValue:(int)e.OldValue;
            int newValue = (int)e.NewValue;

            if (oldValue == newValue)
            {
                return;
            }


            //going down
            if (newValue < oldValue)
            {
                if (oldValue <= 16)
                {
                    if (!TryChangePointsValue(1, true))
                    {
                        process = false;
                        sender.Value = oldValue;
                    }
                }
                else
                {
                    if (!TryChangePointsValue(2, true))
                    {
                        process = false;
                        sender.Value = oldValue;
                    }
                }
            }
            else //going up
            {
                if (newValue <= 16)
                {
                    if (!TryChangePointsValue(1, false))
                    {
                        process = false;
                        sender.Value = oldValue;
                    }
                }
                else
                {
                    if (!TryChangePointsValue(2, false))
                    {
                        process = false;
                        sender.Value = oldValue;
                    }
                }
            }
            
                Calculate();
            
            
        }

        private bool TryChangePointsValue(int value, bool up)
        {
            int currentPoints = 0;
            Int32.TryParse(PointsBox.Text, out currentPoints);

            if (up)
            {
                if (currentPoints == 27)
                {
                    return false;
                }
                if (currentPoints + value > 27)
                {
                    return false;
                }
                currentPoints += value;
            }
            else
            {
                if (currentPoints == 0)
                {
                    return false;
                }
                if (currentPoints - value < 0)
                {
                    return false;
                }
                currentPoints -= value;
            }
            PointsBox.Text = "" + currentPoints;
            return true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            ComboBoxItem item = (ComboBoxItem)cb.Items[cb.SelectedIndex];
            string race = (string)item.Content;

            if (race == "Human")
            {
                StrRacial.Text = "0";
                DexRacial.Text = "0";
                ConRacial.Text = "0";
                IntRacial.Text = "0";
                WisRacial.Text = "0";
                ChaRacial.Text = "0";
            }
            else if (race == "Barbarian")
            {
                StrRacial.Text = "4";
                DexRacial.Text = "0";
                ConRacial.Text = "2";
                IntRacial.Text = "-2";
                WisRacial.Text = "-2";
                ChaRacial.Text = "-2";
            }
            else if (race == "Dark elf")
            {
                StrRacial.Text = "-2";
                DexRacial.Text = "2";
                ConRacial.Text = "-2";
                IntRacial.Text = "4";
                WisRacial.Text = "0";
                ChaRacial.Text = "-2";
            }
            else if (race == "Dwarf")
            {
                StrRacial.Text = "2";
                DexRacial.Text = "0";
                ConRacial.Text = "2";
                IntRacial.Text = "-2";
                WisRacial.Text = "2";
                ChaRacial.Text = "-4";
            }
            else if (race == "Erudite")
            {
                StrRacial.Text = "-4";
                DexRacial.Text = "-2";
                ConRacial.Text = "0";
                IntRacial.Text = "6";
                WisRacial.Text = "2";
                ChaRacial.Text = "-2";
            }
            else if (race == "Gnome")
            {
                StrRacial.Text = "-4";
                DexRacial.Text = "4";
                ConRacial.Text = "-2";
                IntRacial.Text = "4";
                WisRacial.Text = "-2";
                ChaRacial.Text = "0";
            }
            else if (race == "Half elf")
            {
                StrRacial.Text = "0";
                DexRacial.Text = "2";
                ConRacial.Text = "-2";
                IntRacial.Text = "0";
                WisRacial.Text = "-2";
                ChaRacial.Text = "2";
            }
            else if (race == "Halfling")
            {
                StrRacial.Text = "-2";
                DexRacial.Text = "4";
                ConRacial.Text = "0";
                IntRacial.Text = "-2";
                WisRacial.Text = "2";
                ChaRacial.Text = "-2";
            }
            else if (race == "High elf")
            {
                StrRacial.Text = "-4";
                DexRacial.Text = "0";
                ConRacial.Text = "-2";
                IntRacial.Text = "4";
                WisRacial.Text = "4";
                ChaRacial.Text = "2";
            }
            else if (race == "Iksar")
            {
                StrRacial.Text = "4";
                DexRacial.Text = "2";
                ConRacial.Text = "0";
                IntRacial.Text = "0";
                WisRacial.Text = "2";
                ChaRacial.Text = "-4";
            }
            else if (race == "Ogre")
            {
                StrRacial.Text = "6";
                DexRacial.Text = "-2";
                ConRacial.Text = "4";
                IntRacial.Text = "-4";
                WisRacial.Text = "-2";
                ChaRacial.Text = "-4";
            }
            else if (race == "Troll")
            {
                StrRacial.Text = "4";
                DexRacial.Text = "0";
                ConRacial.Text = "6";
                IntRacial.Text = "-4";
                WisRacial.Text = "-2";
                ChaRacial.Text = "-6";
            }
            else if (race == "Vah Shir")
            {
                StrRacial.Text = "2";
                DexRacial.Text = "0";
                ConRacial.Text = "0";
                IntRacial.Text = "-2";
                WisRacial.Text = "0";
                ChaRacial.Text = "0";
            }
            else if (race == "Wood elf")
            {
                StrRacial.Text = "-2";
                DexRacial.Text = "4";
                ConRacial.Text = "-2";
                IntRacial.Text = "0";
                WisRacial.Text = "2";
                ChaRacial.Text = "0";
            }

            Calculate();
        }

        private void Calculate()
        {
            if (StrTotal == null || DexTotal == null || ConTotal == null || IntTotal == null || WisTotal == null || ChaTotal == null)
            {
                return;
            }
            int strBase = StrSpinner.Value.Value;
            int strRacial = 0; int.TryParse(StrRacial.Text, out strRacial);
            int str = strBase + strRacial;
            StrTotal.Text = "" + str;
            StrMod.Text = GetModValue(str);

            int dexBase = DexSpinner.Value.Value;
            int dexRacial = 0; int.TryParse(DexRacial.Text, out dexRacial);
            int dex = dexBase + dexRacial;
            DexTotal.Text = "" + dex;
            DexMod.Text = GetModValue(dex);

            int conBase = ConSpinner.Value.Value;
            int conRacial = 0; int.TryParse(ConRacial.Text, out conRacial);
            int con = conBase + conRacial;
            ConTotal.Text = "" + con;
            ConMod.Text = GetModValue(con);

            int intBase = IntSpinner.Value.Value;
            int intRacial = 0; int.TryParse(IntRacial.Text, out intRacial);
            int intVal = intBase + intRacial;
            IntTotal.Text = "" + intVal;
            IntMod.Text = GetModValue(intVal);

            int wisBase = WisSpinner.Value.Value;
            int wisRacial = 0; int.TryParse(WisRacial.Text, out wisRacial);
            int wisVal = wisBase + wisRacial;
            WisTotal.Text = "" + wisVal;
            WisMod.Text = GetModValue(wisVal);

            int chaBase = ChaSpinner.Value.Value;
            int chaRacial = 0; int.TryParse(ChaRacial.Text, out chaRacial);
            int chaVal = chaBase + chaRacial;
            ChaTotal.Text = "" + chaVal;
            ChaMod.Text = GetModValue(chaVal);
        }

        private string GetModValue(int a)
        {
            if (a == 2 || a == 3)
            {
                return "-4";
            }
            if (a == 4 || a == 5)
            {
                return "-3";
            }
            if (a == 6 || a == 7)
            {
                return "-2";
            }
            if (a == 8 || a == 9)
            {
                return "-1";
            }
            if (a == 12 || a == 13)
            {
                return "1";
            }
            if (a == 14 || a == 15)
            {
                return "2";
            }
            if (a == 16 || a == 17)
            {
                return "3";
            }
            if (a == 18 || a == 19)
            {
                return "4";
            }
            if (a == 20 || a == 21)
            {
                return "5";
            }
            if (a == 22 || a == 23)
            {
                return "6";
            }
            if (a == 24 || a == 25)
            {
                return "7";
            }
            if (a == 26 || a == 27)
            {
                return "8";
            }
            if (a == 28 || a == 29)
            {
                return "9";
            }
            return "0";
        }
    }
}
