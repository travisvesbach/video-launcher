﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video_launcher
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            Text = "Settings";

            tbAnimeDirectory.Text = video_launcher.Properties.Settings.Default.AnimeDirectory;
            tbMovieDirectory.Text = video_launcher.Properties.Settings.Default.MovieDirectory;
            tbTVShowDirectory.Text = video_launcher.Properties.Settings.Default.TVShowDirectory;
            tbBackgroundTopColor.Text = video_launcher.Properties.Settings.Default.BackgroundTopColor;
            tbBackgroundBottomColor.Text = video_launcher.Properties.Settings.Default.BackgroundBottomColor;
            tbButtonColor.Text = video_launcher.Properties.Settings.Default.ButtonColor;
            tbButtonHoverColor.Text = video_launcher.Properties.Settings.Default.ButtonHoverColor;
            tbTextColor.Text = video_launcher.Properties.Settings.Default.TextColor;
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            video_launcher.Properties.Settings.Default.AnimeDirectory = tbAnimeDirectory.Text;
            video_launcher.Properties.Settings.Default.MovieDirectory = tbMovieDirectory.Text;
            video_launcher.Properties.Settings.Default.TVShowDirectory = tbTVShowDirectory.Text;

            if (tbBackgroundTopColor.Text.Length > 0)
            {
                video_launcher.Properties.Settings.Default.BackgroundTopColor = tbBackgroundTopColor.Text;
            }
            if (tbBackgroundBottomColor.Text.Length > 0)
            {
                video_launcher.Properties.Settings.Default.BackgroundBottomColor = tbBackgroundBottomColor.Text;
            }
            if (tbButtonColor.Text.Length > 0)
            {
                video_launcher.Properties.Settings.Default.ButtonColor = tbButtonColor.Text;
            }
            if (tbButtonHoverColor.Text.Length > 0)
            {
                video_launcher.Properties.Settings.Default.ButtonHoverColor = tbButtonHoverColor.Text;
            }
            if (tbTextColor.Text.Length > 0)
            {
                video_launcher.Properties.Settings.Default.TextColor = tbTextColor.Text;
            }
            video_launcher.Properties.Settings.Default.Save();
            this.Close();
        }

        private void btDefaultColors_Click(object sender, EventArgs e)
        {
            tbBackgroundTopColor.Text = video_launcher.Properties.Settings.Default.DefaultBackgroundTopColor;
            tbBackgroundBottomColor.Text = video_launcher.Properties.Settings.Default.DefaultBackgroundBottomColor;
            tbButtonColor.Text = video_launcher.Properties.Settings.Default.DefaultButtonColor;
            tbButtonHoverColor.Text = video_launcher.Properties.Settings.Default.DefaultButtonHoverColor;
            tbTextColor.Text = video_launcher.Properties.Settings.Default.DefaultTextColor;
        }

        private void btAnimeDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdAnimeDirectory = new FolderBrowserDialog();
            if(fbdAnimeDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                video_launcher.Properties.Settings.Default.AnimeDirectory = fbdAnimeDirectory.SelectedPath;
                tbAnimeDirectory.Text = fbdAnimeDirectory.SelectedPath;
            }
        }

        private void btMovieDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMovieDirectory = new FolderBrowserDialog();
            if(fbdMovieDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                video_launcher.Properties.Settings.Default.MovieDirectory = fbdMovieDirectory.SelectedPath;
                tbMovieDirectory.Text = fbdMovieDirectory.SelectedPath;
            }
        }

        private void btTVShowDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdTVShowDirectory = new FolderBrowserDialog();
            if(fbdTVShowDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                video_launcher.Properties.Settings.Default.TVShowDirectory = fbdTVShowDirectory.SelectedPath;
                tbTVShowDirectory.Text = fbdTVShowDirectory.SelectedPath;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTopBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdBackgroundTopColor = new ColorDialog();
            if (cdBackgroundTopColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbBackgroundTopColor.Text = "#" + (cdBackgroundTopColor.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            }

        }

        private void btBackgroundBottomColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdBackgroundBottomColor = new ColorDialog();
            if (cdBackgroundBottomColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbBackgroundBottomColor.Text = "#" + (cdBackgroundBottomColor.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            }
        }

        private void btButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdButtonColor = new ColorDialog();
            if (cdButtonColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbButtonColor.Text = "#" + (cdButtonColor.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            }
        }

        private void btButtonHoverColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdButtonHoverColor = new ColorDialog();
            if (cdButtonHoverColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbButtonHoverColor.Text = "#" + (cdButtonHoverColor.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            }
        }

        private void btTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdTextColor = new ColorDialog();
            if (cdTextColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbTextColor.Text = "#" + (cdTextColor.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            }
        }
    }
}
