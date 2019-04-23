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

namespace _184784Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int count = 0;
        string RightAnswer;
        Random random = new Random();
        //Random random = new Random((int)DateTime.Now.Ticks);
        string DiscoveredAnswer;
        bool FoundLetter = false;
        int Error404;
        int lives = 9;
        string[] easy = new string[10];
        string[] medium = new string[10];
        string[] hard = new string[10];
        int James;
        List<string> ImageList = new List<string>();
        bool GameOver;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            int randomnumber = random.Next(1, 10);
            lblOutput.Text = "";
            //Radio Button to decide the difficulty of the game
            //and pick a random word from list/textfile
            if ((bool)rbEasy.IsChecked)
            {
                System.IO.StreamReader easyread = new System.IO.StreamReader("Easy.txt");
                while (!easyread.EndOfStream)
                {
                    if (count == randomnumber)
                    {
                        easy[randomnumber] = easyread.ReadLine();
                    }
                    else
                    {
                        easyread.ReadLine();
                    }
                    RightAnswer = easy[randomnumber];
                    count++;
                }
                easyread.Close();
                for (int i = 0; i <= RightAnswer.Length; i++)
                {
                    lblOutput.Text += "_" + " ";
                }
            }
            if ((bool)rbMedium.IsChecked)
            {
                count = 0;
                System.IO.StreamReader mediumLevel = new System.IO.StreamReader("Medium.txt");
                while (!mediumLevel.EndOfStream)
                {
                    if (count == randomnumber)
                    {
                        medium[randomnumber] = mediumLevel.ReadLine();
                    }
                    else
                    {
                        mediumLevel.ReadLine();
                    }
                    RightAnswer = medium[randomnumber];
                    count++;
                }
                mediumLevel.Close();
                for (int i = 0; i <= RightAnswer.Length; i++)
                {
                    lblOutput.Text += "_" + " ";
                }
            }
            if ((bool)rbHard.IsChecked)
            {
                count = 0;
                System.IO.StreamReader HardLevel = new System.IO.StreamReader("Hard.txt");
                while (!HardLevel.EndOfStream)
                {
                    if (count == randomnumber)
                    {
                        hard[randomnumber] = HardLevel.ReadLine();
                    }
                    else
                    {
                        HardLevel.ReadLine();
                    }
                    RightAnswer = hard[randomnumber];
                    count++;
                }
                HardLevel.Close();
                for (int i = 0; i <= RightAnswer.Length; i++)
                {
                    lblOutput.Text += "_" + " ";
                }
            }
            lblOutput.Text += Environment.NewLine + "Lives left:" + lives;
        }

        private void BtnLetterCheck_Click(object sender, RoutedEventArgs e)
        {
            //replace the letter of the input if right
            DiscoveredAnswer = lblOutput.Text.ToString();
            for (int i = 0; i < RightAnswer.Length; i++)
            {
                char lettersingle = RightAnswer[i];
                if (lettersingle.ToString() == txtLetterInput.Text)
                {
                    DiscoveredAnswer = DiscoveredAnswer.Remove(i * 2, 1);
                    DiscoveredAnswer = DiscoveredAnswer.Insert(i * 2, lettersingle.ToString());
                    lblOutput.Text = "";
                    lblOutput.Text += DiscoveredAnswer;
                    FoundLetter = true;
                }
            }
            //replace the image when the letter is wrong
            if (FoundLetter == false)
            {
                Error404 += 1;
                if (Error404 == 8)
                {
                    ImageList.Add("original-3541348-2.jpg");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                else if (Error404 == 7)
                {
                    ImageList.Add("");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                else if (Error404 == 6)
                {
                    ImageList.Add("");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                else if (Error404 == 5)
                {
                    ImageList.Add("");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                else if (Error404 == 4)
                {
                    ImageList.Add("");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                else if (Error404 == 3)
                {
                    ImageList.Add("");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                else if (Error404 == 2)
                {
                    ImageList.Add("");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                else if (Error404 == 1)
                {
                    ImageList.Add("");
                    James = lives - Error404;
                    lblOutput.Text += "," + James;
                }
                bool Game1 = false;
                CheckForWin(Game1);
            }
        }
        public bool CheckForWin(bool Win)
        {
            if (lblOutput.Text.ToString() == RightAnswer)
            {
                MessageBox.Show("Congrats.You Win");
                return Win = true;
            }
            else
            {
                return Win = false;
            }
        }

        private bool startGame(bool test)
        {
            if (lblOutput.Text.ToString() == RightAnswer || GameOver == true)
            {
                count = 0;
                int randomnumber = random.Next(0, 10);
                lblOutput.Text = "";

                if ((bool)rbEasy.IsChecked)
                {
                    System.IO.StreamReader easyread = new System.IO.StreamReader("Easy.txt");
                    while (!easyread.EndOfStream)
                    {
                        if (count == randomnumber)
                        {
                            easy[randomnumber] = easyread.ReadLine();
                        }
                        else
                        {
                            easyread.ReadLine();
                        }
                        RightAnswer = easy[randomnumber];
                        count++;
                    }
                    easyread.Close();
                    for (int i = 0; i < RightAnswer.Length; i++)
                    {
                        lblOutput.Text += "_" + " ";
                    }

                    if ((bool)rbMedium.IsChecked)
                    {
                        count = 0;
                        System.IO.StreamReader mediumLevel = new System.IO.StreamReader("Medium.txt");
                        while (!mediumLevel.EndOfStream)
                        {
                            medium[count] = mediumLevel.ReadLine();
                            lblOutput.Text += medium[count] + Environment.NewLine;
                            count++;
                        }
                        mediumLevel.Close();
                    }
                    if ((bool)rbHard.IsChecked)
                    {
                        count = 0;
                        System.IO.StreamReader HardLevel = new System.IO.StreamReader("Hard.txt");
                        while (!HardLevel.EndOfStream)
                        {
                            hard[count] = HardLevel.ReadLine();
                            lblOutput.Text += hard[count] + Environment.NewLine;
                            count++;
                        }
                        HardLevel.Close();
                    }
                }

                lblOutput.Text = RightAnswer;
                lblOutput.Text += Environment.NewLine + "Lives left :" + lives;
                GameOver = false;
                return test = true;
            }
            else
            {
                return test = false;
            }
        }

        private void BtnReplay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }