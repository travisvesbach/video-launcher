   M S B A M L   `   `   `  ����I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  5          video_launcher.MovieIndex   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:video_launcher     5      W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5        N� Title$  
MovieIndex��5
       N� 
Foreground
 �����.��5      ]� ��. .+�5   
   � $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        .��5      �  5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5        FontAwesome5.SvgAwesome     Icon$ 
Solid_Home=�6%      
ButtonIcon#��[  67   �� 5      $��1��6    $
��Home��60   $��Center=�6<   5      5      �� 5      $��1��6   $��50(�6(    �� TextAlignment$ Center=�66   $��Movies��6M   $
��Bold"�6�   ��6[   �� *Window.TextColor+6�   �� 5      -   5        $��	btRefresh��5      $��2��6&   $��10q�6K   .��5      �  5      �� 5       $��* �6+   �� 5!      $
��Auto �6+   .+�5#        $ Solid_CircleNotch=�6%   #��[  6>   �� 5$      -   5        $��	tbRefresh��5$       $��1��61   $��Reload��6A   $��Center=�6O   5%      5&      5'      9� 5(   
   -   5        $��	exFilters��5(   )   $
��Left=�6   $��0,10,0,0q�6:   $��	-2,0,0,-1q�6M    9� ExpandDirection$ Right=�6`   $
��Left=�6x   $��Stretch=�6�   $��22(�6�   $	��200��6�   ��6�   �� *Window.TextColor+��5)      �� 5*       �� Color$ Black��6"    �� Opacity$
 0.45Q�60   ��5,      �� 5-      $��Filters��6    � LayoutTransform 5.      �� 5/      	 �� Angle$		 -90Q�6*   51      .��53      �� $
��Auto=�6   $��0,0,5,0q�6>   .��54      �� .+�55      �� -   5        $��tbSearch��55      6.   9� 56      -   5        $��exGenres��56      $��Genres��6/   .��57      ��   FilterItemsControl#��[ 6K   ��6'   �� *MovieGenres+��58      �� 59   "   .R�5:   &   �� -   5        
 d� 	IsChecked
 5:   /   �� *	IsChecked+ �� Mode$ TwoWay=���6\   �� *Name+6u   5;   #   5=      5>      9� 5?      -   5        $��	exWatched��5?      $��Watched��60   .��5@      �� #��[ 6'   .@�5A      	� -	   5        $��rbAllWatched��5A   A    	� 	GroupName$ 
rbgWatched��6*   $	��All��6o   $

 TrueY�6}   	� 5B      -
   5        $��rbUnwatched��5B   A   $ 
rbgWatched��6*   $��	Unwatched��6n   	� 5C      -   5        $��	rbWatched��5C   A   $ 
rbgWatched��6*   $��Watched��6l   5D      5E      9� 5F      -   5        $��exSort��5F      $
��Sort��6-   .��5G      �� #��[ 6'   .@�5H      	� -   5        $��rbAlphabetical��5H   >   $ rbgSort��6*   $��Alphabetical��6k   $

 TrueY�6�   	� 5I      -   5        $��rbLastWatched��5I   >   $ rbgSort��6*   $��Last Watched��6j   	� 5J      -   5        $��rbYear��5J   >   $ rbgSort��6*   $
��Year��6c   5K      5L      �� 5M      -   5        $��Reset��5M      $
��Left=�6G   5N      5O      5P      �� 5Q   
   -   5        $��lvMovies��5Q       �� SelectionMode$ Single=�6#   $��Disabled=�6a   
������ $��10,0,0,0q�6�   $��0q�6�   ��6:   �� *FilteredMovies+��5R      �� 5S       �� 
TargetType" ��6   .�5T      ��  �� Property � �� �� Value 5U      �� 5V       �� 
TargetType" ��6.   .R�5W   "   �� 5X      5Z      �� 5[       � |� .  62   5\      ��5^      �� 5_      .R�5`      � $��Center=�6    5a      ��5c      �� 5d      .R�5e      �� -   5        $��5q�5e   /   
�������$��0q�6M     PosterButton#��[ 6a    � ContextMenu 5f      �� 5g      .@�5h   "   m�  m� Command 6+   �� *CommandToggleWatched+��6T   �� *WatchedToggleText+ m� Icon 5i   &     5j   *      
Foreground
 � � � 6L   �� *WatchedContextIcon+y�6p   �� *
File_nfo+  StringToVisibilityConverter �� 	Converter# [ 5l   #   5m      .��5o      ]� $	��185��6$   $	��278��60   ��.  $��10q�6S   ��5p      �� 5q   "    j� Stretch$
 None=�6P    �� ImageSource 6-   �� *
Img_poster+6P   .+�5s      �� .+�5t   "   �� 
������� �� CornerRadius$ 13��6<   
 �� Top$ 5��6N    �� Left$ 5��6]   ._�5u   &   ��  �� Orientation$ 
Horizontal=�61   .+�5v   *     $��3q�69   
 � � �$��20��6t    � ToolTip$ Watched��6�    6W   �� *WatchedIcon+y�6�   �� *	Watched+   WatchedToVisibilityConverter# [ 6�   5w   '   5x   #   5y      �� 5z      $��Bottom=�6(   $
��Wrap=�6]   $��Stretch=�6q   $ Center=�6�   $��24(�6�   $��0,0,0,10q�6�   ��6@   �� *DisplayName+��5{   "   �� 5|   &   $ Black��66   $	 0.7Q�6D   5~      5      5�      5�      5�      5�      5�      