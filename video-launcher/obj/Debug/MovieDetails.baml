   M S B A M L   `   `   `  ����I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  5      !    video_launcher.MovieDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:video_launcher     5      W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      -   5          N�Name$  MovieDetailsPage��5
   B    N� 
Foreground
 ����� N� Title 6   �� *MovieData.DisplayName+.��5      � ��5   
   �� 5       j� Stretch$ UniformToFill=�6A    �� ImageSource 6   �� *MovieData.Thumb+6A   .+�5   
   � ��5      �� 5       �� Color$ Black��6"    �� Opacity$
 0.45Q�60    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      � $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5       �� -   5        .��5!      �  5"      �� 5#      $��* �6/   �� 5$      $
��Auto �6/   .+�5&        FontAwesome5.SvgAwesome  	   Icon$	 Solid_Backward=�6)      
ButtonIcon#��[  6?   �� 5'      $��1��6$   $��Center=�64   Movies6W   5(      5)      �� 5*      $��1��6   $��50(�6,   
 �� TextAlignment$
 Center=�6:   $
��Wrap=�6Q   $
��Bold"�6e   ��6w   �� *MovieData.DisplayName+�� 5+      $��2��6   ��6)   �� * MovieData.CommandToggleWatched+ � ToolTip 6\   �� *MovieData.WatchedToggleText+y�6�   �� *MovieData.File_nfo+  StringToVisibilityConverter �� 	Converter# [ .��5,      �  5-      �� 5.      $��* �6/   �� 5/      $
��Auto �6/   .+�51        #��[  6P   	 6)   �� *MovieData.WatchedIcon+6P   �� 52      $��1��6$   ��64   �� *MovieData.WatchedButton+53      54      55      �� 57      $��1��6   $��300,0q�6N   $��24(�6]   $
 Center=�6k   ��6%   �� *MovieData.OriginalTitle+y�6�   �� *MovieData.OriginalTitle+# [ �� 58      $��2��6   $��300,0q�6H   $
��Wrap=�6W   $��24(�6l   $
 Center=�6z   ��6%   �� *MovieData.Tagline+y�6�   �� *MovieData.Tagline+# [ � 5:      $��3��6   $
��0,15q�6     5;      �� 5<      $��* �6'   �� 5=      $��* �6'   �� 5>      $��* �6'   �� 5?      $��* �6'   �� 5@      $��* �6'   .+�5B      �� $��15,0,0,0q�6@   ��6   �� *MovieData.Img_poster+6@   �� 5C      $��1��6   $��2��6/   $
��Auto=�6C   ��5D      �� 5E      $ Black��6*   $	 0.6Q�68   .��5G      �� $��20(�6A   $
��Wrap=�6O   $
��15,0q�6c    �� Padding$ 10q�6q   $��Disabled=�6~   ��6!   �� *MovieData.Plot+5H      5I      �� 5J      $��3��6   $��2��6/   $��16(�6C   $
��15,0q�6Q   $��10q�6_   ��5K      �� 5L      $ Black��6*   $	 0.6Q�68   .@�5N      �� $
��Wrap=�6    y�64   �� *MovieData.Director+# [ �� 5O      
����� �$�	Director:��60    �� 6D   �6H   �� *MovieData.Director+5P      �� 5Q      $
��Wrap=�6    y�64   �� *MovieData.Country+# [ �� 5R      
����� �$�Country:��60    �� 6C   �6G   �� *MovieData.Country+5S      �� 5T      $
��Wrap=�6    y�64   �� *MovieData.Studio+# [ �� 5U      
����� �$�Studio:��60    �� 6B   �6F   �� *MovieData.Studio+5V      �� 5W      $
��Wrap=�6    y�64   �� *MovieData.GenreString+# [ �� 5X      
����� �$�Genre:��60    �� 6A   �6E   �� *MovieData.GenreString+5Y      �� 5Z      $
��Wrap=�6    y�64   �� *MovieData.Set+# [ �� 5[      
����� �$
�Set:��60    �� 6?   �6C   �� *MovieData.Set+5\      �� 5]      $
��Wrap=�6    y�64   �� *MovieData.Runtime+# [ �� 5^      
����� �$�Runtime:��60    �� 6C   �6G   �� *MovieData.Runtime+
 minutes5_      �� 5`      $
��Wrap=�6    y�64   �� *MovieData.SubtitlesString+# [ �� 5a      
����� �$�
Subtitles:��60    �� 6E   �6I   �� *MovieData.SubtitlesString+5b      �� 5c      $
��Wrap=�6    y�64   �� *MovieData.LastWatchedString+# [ �� 5d      
����� �$�Last Watched:��60    �� 6H   �6L   �� *MovieData.LastWatchedString+5e      5g      5h      � 5i      $��4��6   $��15q�6%   .+�5j      �� ��6   �� *MovieData.CommandPlay+.��5k      �  5l      �� 5m      $��* �6/   �� 5n      $
��Auto �6/   .+�5p        $	 
Solid_Play=�6)   #��[  6<   �� 5q      $��1��6$   $��Center=�64   Play6U   5r      5s      �� 5t      ��6   �� *MovieData.CommandOpenTrailer+y�6J   �� *MovieData.Trailer+# [ .��5u      �  5v      �� 5w      $��* �6/   �� 5x      $
��Auto �6/   .+�5z        $	 
Solid_Tape=�6)   #��[  6<   �� 5{      $��1��6$   $��Center=�64   	Trailer6X   5|      5}      5~      5      5�      5�      