﻿using Cryptography.Models;
using System.Collections.Generic;
using System.Windows;



namespace WPFCryptography
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Cypher cypher = new Cypher();
        private readonly Substitution substitution = new Substitution();
        private readonly RSA rsa = new RSA();
        private readonly List<string> cryptography = new List<string>() { "cypher", "substitution", "rsa" };

        public MainWindow()
        {
            InitializeComponent();
            EncryptionChoices.ItemsSource = cryptography;


        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            int selected = EncryptionChoices.SelectedIndex;
            string encryptedMessage;

            // get the selected cryptography
            // then encrypt the message
            if (selected==0)
            {
                encryptedMessage = cypher.Encrypt(plainText.Text);
            }
            else if(selected ==1)
            {
                encryptedMessage = substitution.Encrypt(plainText.Text);
            }
            else if(selected == 2)
            {
                encryptedMessage = rsa.Encrypt(plainText.Text);
            }
            else
            {
                encryptedMessage = "please input a plaintext";
            }

            
            // then show the encrypted message
            encryptedText.Text = encryptedMessage;
        }
    }
}
