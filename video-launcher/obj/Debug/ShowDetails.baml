   M S B A M L   `   `   `  ����I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  5           video_launcher.ShowDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:video_launcher     5      W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      -   5          N�Name$  ShowDetailsPage��5
   A    N� 
Foreground
 ����� N� Title 6   �� *ShowData.DisplayName+.��5      � ��5   
   �� 5       j� Stretch$ UniformToFill=�6@    �� ImageSource 6   �� *ShowData.Thumb+6@   .+�5   
   � ��5      �� 5       �� Color$ Black��6"    �� Opacity$
 0.45Q�60    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5       �� -   5        .��5!      �  5"      �� 5#      $��* �6/   �� 5$      $
��Auto �6/   .+�5&        FontAwesome5.SvgAwesome  	   Icon$	 Solid_Backward=�6)      
ButtonIcon#��[  6?   �� 5'      $��1��6$   $��Center=�64   
TV Shows6Y   5(      5)      �� 5*      $��1��6   $��50(�6,   
 �� TextAlignment$
 Center=�6:   $
��Wrap=�6Q   $
��Bold"�6e   ��6w   �� *ShowData.DisplayName+�� 5+      $��2��6   ��6)   �� *ShowData.CommandToggleWatched+ � ToolTip 6[   �� *ShowData.WatchedToggleText+y�6�   �� *ShowData.File_nfo+  StringToVisibilityConverter �� 	Converter# [ .��5,      �  5-      �� 5.      $��* �6/   �� 5/      $
��Auto �6/   .+�51        #��[  6O   	 6)   �� *ShowData.WatchedIcon+6O   �� 52      $��1��6$   $��Center=�6\   ��64   �� *ShowData.WatchedButton+6\   53      54      55      �� 57      $��1��6   $��300,0q�6M   $��24(�6\   $
 Center=�6j   ��6%   �� *ShowData.OriginalTitle+y�6�   �� *ShowData.OriginalTitle+# [ �� 58      $��2��6   $��300,0q�6G   $
��Wrap=�6V   $��24(�6k   $
 Center=�6y   ��6%   �� *ShowData.Tagline+y�6�   �� *ShowData.Tagline+# [ � 5:      $��3��6   $
��0,15q�6     5;      �� 5<      $��* �6'   �� 5=      $��* �6'   �� 5>      $��* �6'   �� 5?      $��* �6'   �� 5@      $��* �6'   .+�5B      �� $��15,0,0,0q�6?   ��6   �� *ShowData.Img_poster+6?   �� 5C      $��1��6   $��2��6/   $
��Auto=�6C   ��5D      �� 5E      $ Black��6*   $	 0.6Q�68   .��5G      �� $��20(�6@   $
��Wrap=�6N   $
��15,0q�6b    �� Padding$ 10q�6p   $��Disabled=�6}   ��6!   �� *ShowData.Plot+5H      5I      �� 5J      $��3��6   $��2��6/   $��16(�6C   $
��15,0q�6Q   $��10q�6_   ��5K      �� 5L      $ Black��6*   $	 0.6Q�68   .@�5N      �� $
��Wrap=�6    y�64   �� *ShowData.Director+# [ �� 5O      
����� �$�	Director:��60    �� 6D   �6H   �� *ShowData.Director+5P      �� 5Q      $
��Wrap=�6    y�64   �� *ShowData.Country+# [ �� 5R      
����� �$�Country:��60    �� 6C   �6G   �� *ShowData.Country+5S      �� 5T      $
��Wrap=�6    y�64   �� *ShowData.Studio+# [ �� 5U      
����� �$�Studio:��60    �� 6B   �6F   �� *ShowData.Studio+5V      �� 5W      $
��Wrap=�6    y�64   �� *ShowData.GenreString+# [ �� 5X      
����� �$�Genre:��60    �� 6A   �6E   �� *ShowData.GenreString+5Y      �� 5Z      $
��Wrap=�6    y�64   �� *ShowData.Runtime+# [ �� 5[      
����� �$�Episode Runtime:��60    �� 6K   �6O   �� *ShowData.Runtime+
 minutes5\      �� 5]      $
��Wrap=�6    y�64   �� *ShowData.SeasonCountString+# [ �� 5^      
����� �$�Seasons:��60    �� 6C   �6G   �� *ShowData.SeasonCountString+5_      �� 5`      $
��Wrap=�6    y�64   �� *ShowData.EpisodeCountString+# [ �� 5a      
����� �$�	Episodes:��60    �� 6D   �6H   �� *ShowData.EpisodeCountString+5b      �� 5c      $
��Wrap=�6    y�64   �� *ShowData.LastWatchedString+# [ �� 5d      
����� �$�Last Watched:��60    �� 6H   �6L   �� *ShowData.LastWatchedString+5e      5g      5h      � 5i      $��4��6   $��15q�6     5j      �� 5k      $��* �6'   �� 5l      $
��Auto �6'   .+�5n      � .+�5o      �� -   5        .��5p      �  5q      �� 5r   "   $��* �63   �� 5s   "   $
��Auto �63   .+�5u        $	 
Solid_List=�6-   #��[  6?   �� 5v      $��1��6(   $��Center=�68   
Episodes6]   5w      5x      �� 5y      ��6   �� *ShowData.CommandOpenTrailer+y�6M   �� *ShowData.Trailer+# [ .��5z      �  5{      �� 5|   "   $��* �63   �� 5}   "   $
��Auto �63   .+�5        $	 
Solid_Tape=�6-   #��[  6?   �� 5�      $��1��6(   $��Center=�68   	Trailer6\   5�      5�      5�      �� 5�      $��1��6   ��6)   �� *ShowData.CommandToggleAiring+ 6Z   �� *ShowData.AiringToggleText+y�6�   �� *ShowData.File_nfo+# [ .��5�      �  5�      �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�        #��[  6N   	 6)   �� *ShowData.AiringIcon+6N   �� 5�      $��1��6$   $��Center=�6[   ��64   �� *ShowData.AiringButton+6[   5�      5�      5�      5�      5�      5�      