   M S B A M L   `   `   `  ����I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  5          video_launcher.Home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:video_launcher     5      W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5        N� Title$
  Home��5
       � 	Resources 5      .  (video_launcher.StringVisibilityConverter   StringToVisibilityConverter �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� Triggers P� Property	 P� Value
 �� ScaleX �� ScaleY��%�  &	        '��        5   
   6*   �� 5   
   " ��6   .�5      ��  � �� 6+   �� *Window.ButtonColor+�� 5       � �� 6+   �� *Window.TextColor+�� 5       � ��$ 24(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $
 10,5q�6K   $��20, 10q�6Z   $	��400��6j   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver	 . . �5      ��  � �� 63   �� *Window.ButtonHoverColor+�� 5       �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   �� 5        � z� 5!      �� 5"      $

 1.05Q�6-   $
 1.05Q�6;   5$      5%      P� 5&       �@J�	IsFocused	 . . �5'      ��  � �� 63   �� *Window.ButtonHoverColor+�� 5(       �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   �� 5)       � z� 5*      �� 5+      $

 1.05Q�6-   $
 1.05Q�6;   5-      5.      50      51      .��54      �  � RowDefinitions 55   
   �� 56      $��* �6   �� 57      $
��Auto �6   �� 58      $��* �6   .+�5:   
   � $��1��6   $��Center=�6!   .+�5;      �� -   5        $	��250��5;   -   $	��300��6:   y�6F   �� *AnimeDirectory+ �� 	Converter# [   5<      ��%_   '��       �� 5=      " ��6   .�5>      ��  �@��CornerRadius$ 15��69   5?      5@      .��5A      ]� $��15q�6   .+�5B      �� $��Bottom=�6     �� TextAlignment$ Center=�68   $��30(�6O   $
��Bold"�6]   $��Anime��6o   � 5C      $��Center=�6    $��15q�6=   .+�5D        FontAwesome5.SvgAwesome     Icon$ Solid_PhotoVideo=�6)      
Foreground 6A   �� *Window.TextColor+5E      5F      5G      �� 5H      -   5        $	��250��5H   -   $	��300��6:   y�6F   �� *MovieDirectory+# [   5I      ��%_   '��       �� 5J      " ��6   .�5K      ��  �@��CornerRadius$ 15��69   5L      5M      .��5N      ]� $��15q�6   .+�5O      �� $��Bottom=�6    $ Center=�68   $��30(�6O   $
��Bold"�6]   $��Movies��6o   � 5P      $��Center=�6    $��15q�6=   .+�5Q        $ 
Solid_Film=�6)    6;   �� *Window.TextColor+5R      5S      5T      �� 5U      -   5        $	��250��5U   *   $	��300��67   y�6C   �� *TVShowDirectory+# [   5V      ��%_   '��       �� 5W      " ��6   .�5X      ��  �@��CornerRadius$ 25��69   5Y      5Z      .��5[      ]� $��15q�6   .+�5\      �� $��Bottom=�6    $ Center=�68   $��30(�6O   $
��Bold"�6]   $��TV Shows��6o   � 5]      $��Center=�6    $��15q�6=   .+�5^        $ Solid_TV=�6)    69   �� *Window.TextColor+5_      5`      5a      5b      �� 5c   
   $��2��6   .+�5d      �� -   5         �� Bottom$ 10��5d       �� Left$ 10��6(    5e      ��%^   '��       �� 5f      " ��6   .�5g      ��  �@��CornerRadius$ 5��69   5h      5i      .��5j      � .+�5k        $ 
Solid_Cogs=�6%   $��20��6_   $��0,0,10,0q�6k    67   �� *Window.TextColor+6k   �� 5l      $ Center=�6    
Settings6A   5m      5n      5o      5p      5q      