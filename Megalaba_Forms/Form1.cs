﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Megalaba_Forms
{
    public partial class Form1 : Form
    {//rock, paper, scissors game with COM
        static Type com1 = Type.GetTypeFromProgID("Megalaba_COM.ComClass1");
        static dynamic com1Instance = Activator.CreateInstance(com1);

        int rounds = 3;
        int timerPerRound = 6;

        bool gameover = false;

        

        

        string opponentchoice;

        string playerChoice;

        int playerwins;
        int opponentwins;


        public Form1()
        {
            InitializeComponent();
            countDownTimer.Enabled = false;
            playerChoice = "none";
            txtTime.Text = "5";
            btnPaper.Enabled = false;
            btnRock.Enabled = false;
            btnScissors.Enabled = false;
            Thread WaitForOpponentThread = new Thread(WaitForOpponent);
            WaitForOpponentThread.Start();
            WaitForOpponentThread.Join();
        }
        private void WaitForOpponent()
        {
                while (true)
                {
                    if (com1Instance.IsReady())
                    {
                    OpponentLabel.Text = "Your Opponent";
                    btnPaper.Enabled = true;
                    btnRock.Enabled = true;
                    btnScissors.Enabled = true;
                    break;
                    }
                    else
                    {
                        
                    }
                    Thread.Sleep(200);
                }
        }
        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
            com1Instance.SendData(0x11);
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
            com1Instance.SendData(0x12);
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
            com1Instance.SendData(0x13);
        }

        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtTime.Text = timerPerRound.ToString();
            roundsText.Text = "Rounds: " + rounds;

            if(timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 6;

                
                opponentchoice ;

                switch(opponentchoice)
                {
                    case "rock":
                        picCPU.Image = Properties.Resources.rock;
                        break;
                    case "paper":
                        picCPU.Image = Properties.Resources.paper;
                        break;
                    case "scissor":
                        picCPU.Image = Properties.Resources.scissors;
                        break;
                }


                if(rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if(playerwins > opponentwins)
                    {
                        MessageBox.Show("Player Wins This Game");
                    }
                    else
                    {
                        MessageBox.Show("You loose This Game");
                    }

                    gameover = true;
                }


            }
        }


        private void checkGame()
        {
            startNextRound();
        }

        public void startNextRound()
        {

            if (gameover)
            {



                return;
            }

            txtMessage.Text = "Player: " + playerwins + " - " + "CPU: " + opponentwins;

            playerChoice = "none";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;
        }

        private void restartGame(object sender, EventArgs e)
        {
            playerwins = 0;
            opponentwins = 0;
            rounds = 3;
            txtMessage.Text = "Player: " + playerwins + " - " + "CPU: " + opponentwins;

            playerChoice = "none";
            txtTime.Text = "5";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;

            gameover = false;
        }
    }
}
