   M S B A M L   `   `   `  ����I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  5      !    video_launcher.ShowEpisodes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:video_launcher     5      W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      -   5          N� 
Foreground
  ����� N� Title 5      �� *ShowData.DisplayName+ � 	Resources 5       �� 
TargetType   EpisodeButton �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value �� RelativeSource �� AncestorType��%�  &	        �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 15��6K   $ 10q�6]   ._�5      �� $��Center=�6/   $
��20,0q�6J   5      5      5      	 5      P� 5      
 �@J�IsMouseOver . . �5      ��  � �� 63   �� *Window.ButtonHoverColor+ �� " N��� 5       �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   5      P� 5      
 �@J�	IsFocused . . �5      ��  � �� 63   �� *Window.ButtonHoverColor+ �� " N��� 5        �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   5!      5#      5$      .��5&      � ��5'   
   �� 5(       j� Stretch$ UniformToFill=�6@    �� ImageSource 6   �� *ShowData.Thumb+6@   .+�5*   
   � ��5+      �� 5,       �� Color$ Black��6"    �� Opacity$	 0.8Q�60    � RowDefinitions 5.      �� 5/      $
��Auto �6    �� 50      $��* �6     � ColumnDefinitions 52      �� 53      $��* �6#   �� 54      $��* �6#   �� 55      $��* �6#   �� 56      $��* �6#   �� 57      $��* �6#   .+�59      � $��3��6    5:      �� 5;      $
��Auto �6'   �� 5<      $��* �6'   .+�5>      �� -   5        .��5?      �  5@      �� 5A      $��* �6/   �� 5B      $
��Auto �6/   .+�5D        FontAwesome5.SvgAwesome     Icon$ Solid_Backward=�6)     
ButtonIcon#��[ 6?   �� 5E      $��1��6$   $��Center=�64    �� TextAlignment$ Center=�6O   About6m   5F      5G      �� 5H      $��1��6   $��50(�6,   $ Center=�6:   $
��Wrap=�6Q   $
��Bold"�6e   ��6w   �� *ShowData.DisplayName+5I      �� 5J      $��1��6   $
��Auto=�6(   $��Center=�6K   $��20q�6f   $
��10,0q�6s   .��5K      �� -   5        $��SeasonsItems��5K      
������ $��0q�6u   ��63   �� *ShowData.Seasons+��5L      �� 5M      .R�5N      �� -   5        #��[  5N   S   
 � Tag 6<   �� *Number+.��5O   "   �� $��1��6,   $��18(�6<   $��Center=�6J   ��6g   �� *Name+5P      5Q      5S      5T      �� 5U      $��1��6   $��1��6(   $��2��69   $��Center=�6M   $
��Auto=�6h   $
��10,0q�6�   .��5V      �� -   5        $��EpisodeItems��5V      
������ $��0q�6u   ��63   �� *FilteredEpisodes+��5W      �� 5X      .R�5Y      �� -   5        #��[  5Y   [    6=   �� *EpisodeNumber+ � ContextMenu 5Z   "   �� 5[   &   .@�5\   *   m�  m� Command 63   �� *CommandToggleWatched+��6\   �� *WatchedToggleText+ m� Icon 5]   .     5^   2      
Foreground
 � � � 6T   �� *WatchedContextIcon+y�6x   �� *
File_nfo+  StringToVisibilityConverter �� 	Converter# [ 5`   +   5a   '    J� InputBindings 5c   "   d� 5d   &    d� Gesture$ LeftDoubleClicka�63    �� Command 6M   �� *CommandPlay+.��5f   "   �  5g   &   �� 5h   *   $��30 �6;   �� 5i   *   $��40 �6;   �� 5j   *   $��* �6;   .+�5l   &     
 � � �$��20��6e    � ToolTip$ Watched��6�    6H   �� *WatchedIcon+y�6q   �� *	Watched+   WatchedToVisibilityConverter# [ 6�   �� 5m   &   $��1��60   $��18(�6e   $
 Left=�6s   ��6@   �� *EpisodeNumberString+6s   �� 5n   &   $��2��60   $��18(�6]   ��6@   �� *DisplayName+6]   5o   #   5p      5q      5s      5t      � 5u      $��2��6   $��3��6$   $��2��65   $��15q�6I   y�6U   �� *SelectedEpisode+  NullToVisibilityConverter# [  5v      �� 5w      $
��Auto �6$   �� 5x      $
��Auto �6$   �� 5y      $��* �6$   �� 5z      $
��Auto �6$   �� 5{      $
��Auto �6$   .+�5}      �� $��Center=�6I   $��30(�6f   $
��Wrap=�6t   ��6   �� *SelectedEpisode.DisplayName+6t   �� 5~      $��1��6   $��15,0,0,0q�6N   $	��300��6`   ��6%   �� *SelectedEpisode.Thumb+6`   �� 5      $��2��6   $
��Auto=�6,   .��5�      �� $
��Wrap=�6F   $��18(�6Z   $��15q�6h   $ Center=�6t   ��6    �� *SelectedEpisode.Plot+6t   5�      � 5�      $��3��6   $��10q�6$    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��16(�6    y�6.   �� *SelectedEpisode.Aired+# [ �� 5�      $�Aired:��6   
����� �6,    �� 5�      �6   �� *SelectedEpisode.Aired+5�      �� 5�      $��2��6    $��16(�60   $��Right=�6>   y�6Z   �� *#!SelectedEpisode.LastWatchedString+# [ �� 5�      $�Last Watched:��6   
����� �63    �� 5�      �6   �� *#!SelectedEpisode.LastWatchedString+5�      5�      � 5�      $��4��6    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   �� 5�      $
��Auto �6+   .+�5�      �� ��6   �� *SelectedEpisode.CommandPlay+.��5�      �  5�      �� 5�   "   $��* �63   �� 5�   "   $
��Auto �63   .+�5�        $ 
Solid_Play=�6-   #��[ 6?   �� 5�      $��1��6(   $��Center=�68   Play6Y   5�      5�      �� 5�      $��2��6   ��6-   �� *&$SelectedEpisode.CommandToggleWatched+ 6f   �� *#!SelectedEpisode.WatchedToggleText+y�6�   �� *SelectedEpisode.File_nfo+# [ .��5�      �  5�      �� 5�   "   $��* �63   �� 5�   "   $
��Auto �63   .+�5�        #��[ 6Z    6-   �� *SelectedEpisode.WatchedIcon+6Z   �� 5�      $��1��6(   $��Center=�6g   ��68   �� *SelectedEpisode.WatchedButton+6g   5�      5�      5�      5�      5�      5�      5�      