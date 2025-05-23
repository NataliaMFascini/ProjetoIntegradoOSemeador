﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LivrariaEBiblioteca
{
    public partial class frmLogin : Form
    {
        string cargo;
        public int codUsu;
        public string nome;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                if (txtUsuario.Text.Equals(""))
                {
                    MessageBox.Show("Insira um usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }
                else if (txtSenha.Text.Equals(""))
                {
                    MessageBox.Show("Insira a senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Focus();
                }
                else
                {
                    if (acessarSistema(usuario, senha))
                    {
                        if (txtUsuario.Text != usuario || txtSenha.Text != senha)
                        {
                            MessageBox.Show("Usuário ou senha incorretos.", "MENSAGEM DO SISTEMA", MessageBoxButtons.OK);
                            txtUsuario.Clear();
                            txtSenha.Clear();
                            txtUsuario.Focus();
                            return;
                        }
                        frmMenuPrincipal abrir = new frmMenuPrincipal(cargo, nome, codUsu);
                        abrir.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário inexistente.", "MENSAGEM DO SISTEMA", MessageBoxButtons.OK);
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao acessar o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool acessarSistema(string usuario, string senha)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select login, senha, cargo, nome, codUsu from tbUsuario where login = @login and senha = @senha";
                comm.CommandType = CommandType.Text;

                comm.Connection = Conexao.obterConexao();

                comm.Parameters.Clear();
                comm.Parameters.Add("@login", MySqlDbType.VarChar, 50).Value = usuario;
                comm.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = senha;

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                bool resp = DR.HasRows;
                cargo = DR.GetString(2);
                nome = DR.GetString(3);
                codUsu = DR.GetInt32(4);


                Conexao.fecharConexao();

                return resp;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao acessar o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }
    }
}
