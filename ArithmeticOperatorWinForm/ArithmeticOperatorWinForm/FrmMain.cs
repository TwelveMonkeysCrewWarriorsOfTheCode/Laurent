using ArithmeticOperatorBLL;
using ArithmeticOperatorDTO;
using ArithmeticOperatorWUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArithmeticOperatorWinForm
{
    public partial class Home : Form
    {
        public Fraction Fraction1;
        public Fraction Fraction2;

        public Home()
        {
            InitializeComponent();
            CbCompare.SelectedIndex = 0;
            CbOperator.SelectedIndex = 0;
        }


        #region Menu qui gére l'opération par rapport au choix de l'utilisateur
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (TbDecimal.Text != string.Empty) TbDecimal.Text = string.Empty;
            
            bool choice = false;
            choice = ZeroVerificationOperator(choice);
            string menuSelected = Convert.ToString(CbOperator.SelectedItem);

            while (!choice)
            {
                Fraction Result = new();

                switch (menuSelected)
                {
                    case "+":
                        Result = Fraction1 + Fraction2;
                        FractionIsEmpty(Result);
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Operator");
                        choice = true;
                        break;
                    case "-":
                        Result = Fraction1 - Fraction2;
                        FractionIsEmpty(Result);
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Operator");
                        choice = true;
                        break;
                    case "*":
                        Result = Fraction1 * Fraction2;
                        FractionIsEmpty(Result);
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Operator");
                        choice = true;
                        break;
                    case "/":
                        Result = Fraction1 / Fraction2;
                        FractionIsEmpty(Result);
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Operator");
                        choice = true;
                        break;
                    default:
                        MessageBox.Show("Vous n'avez pas choisi d'opérateur");
                        choice = true;
                        break;
                }
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            bool choice = false;
            choice = ZeroVerificationCompare(choice);

            string menuSelected = Convert.ToString(CbCompare.SelectedItem);

            while (!choice)
            {
                bool Result;

                switch (menuSelected)
                {
                    case "Egal":
                        Result = Fraction1 == Fraction2;
                        if (Result)
                        {
                            TbAnswer.ForeColor = Color.Green;
                            TbAnswer.Text = $"{Fraction1} est égale à {Fraction2}";
                        }
                        else
                        {
                            TbAnswer.ForeColor = Color.Red;
                            TbAnswer.Text = $"{Fraction1} n'est pas égale à {Fraction2}";
                        }
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Compare");
                        choice = true;
                        break;
                    case "Différent":
                        Result = Fraction1 != Fraction2;
                        if (Result)
                        {
                            TbAnswer.ForeColor = Color.Green;
                            TbAnswer.Text = $"{Fraction1} n'est pas égale à {Fraction2}";
                        }
                        else
                        {
                            TbAnswer.ForeColor = Color.Red;
                            TbAnswer.Text = $"{Fraction1} est égale à {Fraction2}";
                        }
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Compare");
                        choice = true;
                        break;
                    case "Plus grand":
                        Result = Fraction1 > Fraction2;
                        if (Result)
                        {
                            TbAnswer.ForeColor = Color.Green;
                            TbAnswer.Text = $"{Fraction1} est plus grand que {Fraction2}";
                        }
                        else
                        {
                            TbAnswer.ForeColor = Color.Red;
                            TbAnswer.Text = $"{Fraction1} est plus petit que {Fraction2}";
                        }
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Compare");
                        choice = true;
                        break;
                    case "Plus petit":
                        Result = Fraction1 < Fraction2;
                        if (Result)
                        {
                            TbAnswer.ForeColor = Color.Green;
                            TbAnswer.Text = $"{Fraction1} est plus petit queest plus grand que {Fraction2}";
                        }
                        else
                        {
                            TbAnswer.ForeColor = Color.Red;
                            TbAnswer.Text = $"{Fraction1} est plus grand que {Fraction2}";
                        }
                        if (CbSaveOperation.Checked) FileOperationBLL.SaveToFileBLL(Fraction1, Fraction2, Result, menuSelected, "Compare");
                        choice = true;
                        break;
                    default:
                        MessageBox.Show("Vous n'avez pas choisi d'opérateur");
                        choice = true;
                        break;
                }
            }
        }
        #endregion


        #region Abonnements qui gère les règles pour les NumericUpDown
        private void Fraction1Operator_ValueChanged(object sender, EventArgs e)
        {
            if (Integer1.Value != 0)
            {
                if (Numerator1.Value < 0)
                {
                    Numerator1.Value = -Numerator1.Value;
                    MessageBox.Show("Le numérateur ne peut pas être négatif si l'entier est différent de 0");
                }
                if (Denominator1.Value < 0)
                {
                    Denominator1.Value = -Denominator1.Value;
                    MessageBox.Show("Le dénominateur ne peut pas être négatif si l'entier est différent de 0");
                }
            }

            if (Numerator1.Value == 0 && Convert.ToChar(CbOperator.SelectedItem) == '/')
            {
                MessageBox.Show("Le numerateur ne peu pas être à 0 pour une division");
            }

            if (Denominator1.Value == 0)
            {
                MessageBox.Show("Le dénominateur ne peu pas être à 0");
            }
        }

        private void Fraction2Operator_ValueChanged(object sender, EventArgs e)
        {
            if (Integer2.Value != 0)
            {
                if (Numerator2.Value < 0)
                {
                    Numerator2.Value = -Numerator2.Value;
                    MessageBox.Show("Le numérateur ne peut pas être négatif si l'entier est différent de 0");
                }
                if (Denominator2.Value < 0)
                {
                    Denominator2.Value = -Numerator2.Value;
                    MessageBox.Show("Le dénominateur ne peut pas être négatif si l'entier est différent de 0");
                }
            }

            if (Numerator2.Value == 0 && Convert.ToChar(CbOperator.SelectedItem) == '/')
            {
                MessageBox.Show("Le numerateur ne peu pas être à 0 pour une division");
            }

            if (Denominator2.Value == 0)
            {
                MessageBox.Show("Le dénominateur ne peu pas être à 0");
            }
        }

        private void Fraction1Compare_ValueChanged(object sender, EventArgs e)
        {
            if (IntCompare1.Value != 0)
            {
                if (NumCompare1.Value < 0)
                {
                    NumCompare1.Value = -NumCompare1.Value;
                    MessageBox.Show("Le numérateur ne peut pas être négatif si l'entier est différent de 0");
                }
                if (DenomCompare1.Value < 0)
                {
                    DenomCompare1.Value = -DenomCompare1.Value;
                    MessageBox.Show("Le dénominateur ne peut pas être négatif si l'entier est différent de 0");
                }
            }

            if (DenomCompare1.Value == 0)
            {
                MessageBox.Show("Le dénominateur ne peu pas être à 0");
            }
        }

        private void Fraction2Compare_ValueChanged(object sender, EventArgs e)
        {
            if (IntCompare2.Value < 0)
            {
                if (NumCompare2.Value < 0)
                {
                    NumCompare2.Value = -NumCompare2.Value;
                    MessageBox.Show("Le numérateur ne peut pas être négatif si l'entier est différent de 0");
                }
                if (DenomCompare2.Value < 0)
                {
                    DenomCompare2.Value = -DenomCompare2.Value;
                    MessageBox.Show("Le dénominateur ne peut pas être négatif si l'entier est différent de 0");
                }
            }

            if (DenomCompare2.Value == 0)
            {
                MessageBox.Show("Le dénominateur ne peu pas être à 0");
            }
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Vérifie si aucun dénominateur n'est pas 0 ou le numérateur dans le cas d'une division
        /// Si false ne rentre pas dans le switch
        /// </summary>
        /// <param name="pChoice">bool qui permet de rentrer dans le switch</param>
        /// <returns>bool</returns>
        private bool ZeroVerificationOperator(bool pChoice)
        {
            if ((int)Denominator1.Value != 0 && (int)Denominator2.Value != 0)
            {
                if ((int)Numerator1.Value == 0 || (int)Numerator2.Value == 0 && Convert.ToChar(CbOperator.SelectedItem) == '/')
                {
                    MessageBox.Show("Aucun numérateur ne doit être égal à 0 dans une division");
                    pChoice = true;
                }
                else
                {
                    Fraction1 = new Fraction((int)Integer1.Value, (int)Numerator1.Value, (int)Denominator1.Value);
                    Fraction2 = new Fraction((int)Integer2.Value, (int)Numerator2.Value, (int)Denominator2.Value);
                }                
            }
            else
            {
                MessageBox.Show("Aucun dénominateur ne doit être égal à 0 ");
                pChoice = true;
            }            
            return pChoice;
        }

        /// <summary>
        /// Vérifie si aucun dénominateur n'est pas 0
        /// Si false ne rentre pas dans le switch
        /// </summary>
        /// <param name="pChoice">bool qui permet de rentrer dans le switch</param>
        /// <returns>bool</returns>
        private bool ZeroVerificationCompare(bool pChoice)
        {
            if ((int)DenomCompare1.Value != 0 && (int)DenomCompare2.Value != 0)
            {
                Fraction1 = new Fraction((int)IntCompare1.Value, (int)NumCompare1.Value, (int)DenomCompare1.Value);
                Fraction2 = new Fraction((int)IntCompare2.Value, (int)NumCompare2.Value, (int)DenomCompare2.Value);
            }
            else
            {
                MessageBox.Show("Aucun dénominateur ne doit être égal à 0 ");
                pChoice = true;
            }
            return pChoice;
        }

        /// <summary>
        /// Vérifie si le résultat de la fraction est juste un entier et n'affiche
        /// rien dans la partie fraction de la réponse
        /// </summary>
        /// <param name="pResult">Résultat de l'opération sur la fraction</param>
        private void FractionIsEmpty(Fraction pResult)
        {
            if (pResult.Numerator != 0)
            {
                NumeratorResult.Text = Convert.ToString(pResult.Numerator);
                DenominatorResult.Text = Convert.ToString(pResult.Denominator);
            }
            else
            {
                NumeratorResult.Text = "";
                DenominatorResult.Text = "";
            }
            IntegerResult.Text = Convert.ToString(pResult.Integer);
        }
        #endregion

        #region Overture de la fenêtre qui afficher les fichiers sauvegardés
        private void opérationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string operativeType = "Operator";
            using (FrmDataList DataFrm = new(operativeType))
            {
                DataFrm.ShowDialog();
            }
        }

        private void comparaisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string operativeType = "Compare";
            using (FrmDataList DataFrm = new(operativeType))
            {
                DataFrm.ShowDialog();
            }
        }
        #endregion

        #region Gère le bouton de conversion en décimale
        private void BtDecimalConvert_Click(object sender, EventArgs e)
        {
            Fraction Result = new();
            if (IntegerResult.Text != string.Empty && NumeratorResult.Text != string.Empty)
            {
                Result = new(int.Parse(IntegerResult.Text), int.Parse(NumeratorResult.Text), int.Parse(DenominatorResult.Text));
            }
            else
            {
                if (IntegerResult.Text == string.Empty) Result = new(0, int.Parse(NumeratorResult.Text), int.Parse(DenominatorResult.Text));
                else Result = new(int.Parse(IntegerResult.Text));
            }
            decimal convertion = (decimal)Result;
            TbDecimal.Text = Convert.ToString(convertion);
        }

        private void IntegerResult_TextChanged(object sender, EventArgs e)
        {
            if (IntegerResult.Text != string.Empty || DenominatorResult.Text != string.Empty) BtDecimalConvert.Enabled = true;
        }
        #endregion        
    }
}
