   M S B A M L   `   `   `  ����I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  5          video_launcher.ShowIndex   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:video_launcher     5      W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5        N� Title$  	ShowIndex��5
      .��5      ]� ��. .+�5   
   � $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        .��5      �  5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5        FontAwesome5.SvgAwesome     Icon$ 
Solid_Home=�6%      
ButtonIcon#��[  67   �� 5      $��1��6    $
��Home��60   $��Center=�6<   ��6W   �� *Window.TextColor+5      5      �� 5      $��50(�6   $��1��6&    �� TextAlignment$ Center=�67   $
��Bold"�6�   ��6N   �� *
ShowType+��6h   �� *Window.TextColor+6�   �� 5      -   5        $��	btRefresh��5      $��2��6&   .��5      �  5      �� 5       $��* �6+   �� 5!      $
��Auto �6+   .+�5#        $ Solid_CircleNotch=�6%   #��[  6>   �� 5$      -   5        $��	tbRefresh��5$       $��1��61   $��Reload��6A   $��Center=�6O   ��6j   �� *Window.TextColor+5%      5&      5'      9� 5(   
   -   5        $��	exFilters��5(   )   $
��Left=�6   $��0,10,0,0q�6:   $��	-2,0,0,-1q�6M    9� ExpandDirection$ Right=�6`   $
��Left=�6x   $��Stretch=�6�   $��22(�6�   $	��200��6�   ��6�   �� *Window.TextColor+��5)      �� 5*       �� Color$ Black��6"    �� Opacity$
 0.45Q�60   ��5,      �� 5-      $��Filters��6    � LayoutTransform 5.      �� 5/       �� Angle$	 -90Q�6*   51      .��53      �� $
��Auto=�6   $��0,0,5,0q�6>   .��54      �� $��0,0,0,0q�6   .+�55      �� -   5        $��tbSearch��55      6.   9� 56      -   5        $��exAiring��56      $��Airing��6/   .��57      ��   FilterItemsControl#��[ 6'   .@�58      	� -   5        $��rbAllAiring��58   @   	 	� 	GroupName$	 	rbgAiring��6*   $	��All��6l   
 d� 	IsChecked$

 TrueY�6z   	� 59      -   5        $��rbAiring��59   @   $	 	rbgAiring��6*   $��
Airing Now��6i   	� 5:      -	   5        $��rbOnHold��5:   @   $	 	rbgAiring��6*   $��Waiting��6i   	� 5;      -
   5        $��rbCompleted��5;   @   $	 	rbgAiring��6*   $��	Completed��6l   5<      5=      9� 5>      -   5        $��exGenres��5>      $��Genres��6/   .��5?      �� #��[ 6J   ��6'   �� *
ShowGenres+��5@      �� 5A   "   .R�5B   &   �� -   5        
 5B   /   �� *	IsChecked+ �� Mode$ TwoWay=���6\   �� *Name+6u   5C   #   5E      5F      9� 5G      -   5        $��	exWatched��5G      $��Watched��60   .��5H      �� #��[ 6'   .@�5I      	� -   5        $��rbAllWatched��5I   A   $	 
rbgWatched��6*   $	��All��6o   $

 TrueY�6}   	� 5J      -   5        $��rbInProgress��5J   A   $	 
rbgWatched��6*   $��In Progress��6o   	� 5K      -   5        $��rbUnwatched��5K   A   $	 
rbgWatched��6*   $��	Unwatched��6n   	� 5L      -   5        $��	rbWatched��5L   A   $	 
rbgWatched��6*   $��Watched��6l   5M      5N      9� 5O      -   5        $��exSort��5O      $
��Sort��6-   .��5P      �� #��[ 6'   .@�5Q      	� -   5        $��rbAlphabetical��5Q   >   $	 rbgSort��6*   $��Alphabetical��6k   $

 TrueY�6�   	� 5R      -   5        $��rbLastWatched��5R   >   $	 rbgSort��6*   $��Last Watched��6j   	� 5S      -   5        $��rbYear��5S   >   $	 rbgSort��6*   $
��Year��6c   5T      5U      �� 5V      -   5        $��Reset��5V      $
��Left=�6G   5W      5X      5Y      �� 5Z   
   -   5        $��lvShows��5Z       �� SelectionMode$ Single=�6"   $��Disabled=�6_   
������ $��10,0,0,0q�6�   $��0q�6�   ��69   �� *FilteredShows+��5[      �� 5\       �� 
TargetType" ��6   .�5]      ��  �� Property � �� �� Value 5^      �� 5_       �� 
TargetType" ��6.   .R�5`   "   �� 5a      5c      �� 5d       � |� .  62   5e      ��5g      �� 5h      .R�5i      � $��Center=�6    5j      ��5l      �� 5m      .R�5n      �� -   5        $��5q�5n   .   
�������$��0q�6L     PosterButton#��[ 6`    � ContextMenu 5o      �� 5p      .@�5q   "   m�  m� Command 6+   �� *CommandToggleWatched+��6T   �� *WatchedToggleText+ m� Icon 5r   &     5s   *      
Foreground
 � � � 6L   �� *WatchedContextIcon+y�6p   �� *
File_nfo+  StringToVisibilityConverter �� 	Converter# [ 5u   #   m� 5v   "    6+   �� *CommandToggleAiring+��6S   �� *AiringToggleText+ 5w   &     5x   *   
 � � � 6L   �� *AiringContextIcon+y�6o   �� *
File_nfo+# [ 5z   #   5{      .��5}      ]� $	��185��6$   $	��278��60   ��.  $��10q�6S   ��5~      �� 5   "    j� Stretch$
 Fill=�6P    �� ImageSource 6-   �� *
Img_poster+6P   .+�5�      �� .+�5�   "   �� 
������� �� CornerRadius$ 13��6<   
 �� Top$ 5��6N    �� Left$ 5��6]   ._�5�   &   ��  �� Orientation$ 
Horizontal=�61   .+�5�   *     $��3q�69   
 � � �$��20��6t    � ToolTip$ Watched��6�    6W   �� *WatchedIcon+y�6�   �� *	Watched+   WatchedToVisibilityConverter# [ 6�     5�   *   $��5q�69   
 � � �$��20��6s   $ Watched��6�    6W   �� *
AiringIcon+y�6   �� *Airing+  AiringToVisibilityConverter# [ 6�   5�   '   5�   #   5�      �� 5�      $��Bottom=�6(   $
��Wrap=�6]   $��Stretch=�6q   $ Center=�6�   $��24(�6�   $��0,0,0,10q�6�   ��6@   �� *DisplayName+��5�   "   �� 5�   &   $ Black��66   $	 0.7Q�6D   5�      5�      5�      5�      5�      5�      5�      