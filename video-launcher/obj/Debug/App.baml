   M S B A M L   `   `   `  ����I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  5          video_launcher.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      (localclr-namespace:video_launcher  5      4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        �� 	Resources  5          BooleanToVisibilityConverter,   &video_launcher.NullVisibilityConverter  NullToVisibilityConverter.  (video_launcher.StringVisibilityConverter  StringToVisibilityConverter/  )video_launcher.WatchedVisibilityConverter   WatchedToVisibilityConverter/  )video_launcher.AiringVisibilityController  AiringToVisibilityConverter  FontAwesome �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property	 P� Value
 �� RelativeSource �� AncestorType �� ScaleX �� ScaleY  PosterButton  FontAwesome5.SvgAwesome  
ButtonIcon  FilterItemsControl��%K  &	        &	      &	 &     &	 9     &	 L     &	 _     '�� �     &	 �    &	 \    '9� �    &	 �	    '�� i
    '	�      �� 5	   
   6'     5
   
   6(     5   
   6*     5   
   6+     5   
   6+   *�5   
   MI/video_launcher;component/fonts/FontAwesome.otf#Font Awesome 5 Free Solid)�6t   �� 5   
   " ��6   .�5      ��  � �� 6+   �� *Window.ButtonColor+�� 5       � �� 6+   �� *Window.TextColor+�� 5       � ��$ 40��6'   �� 5       � ��$ 18(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 15��6K   $ 10q�6]   ._�5      �� $��Center=�6/   $
��10,0q�6J   5      5      5        5!      P� 5"       �@J�IsMouseOver	 . . �5#      ��  � �� 63   �� *Window.ButtonHoverColor+
 �� " N��� 5$       �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   �� 5%       � z� 5&      �� 5'      $
 1.05Q�6-   $
 1.05Q�6;   5)      5*      P� 5+       �@J�	IsFocused	 . . �5,      ��  � �� 63   �� *Window.ButtonHoverColor+
 �� " N��� 5-       �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   �� 5.       � z� 5/      �� 50      $
 1.03Q�6-   $
 1.03Q�6;   52      53      55      �� 57   
   " ��6   .�58      ��  � ��
 ���� 6+   �� 59       � ��
 �����6+   �� 5:       � �� 5;      �� 5<      " ��6&   .R�5=      �� #��z��6!   $ 15��6K   ._�5>      �� $��Center=�6/   $��Center=�6L   5?      5@      5B       5C      P� 5D       �@J�IsMouseOver	 . . �5E      ��  � �� 63   �� *Window.ButtonHoverColor+
 �� " N��� 5F       �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   �� 5G       � z� 5H      �� 5I      $
 1.03Q�6-   $
 1.03Q�6;   5K      5L      P� 5M       �@J�	IsFocused	 . . �5N      ��  � �� 63   �� *Window.ButtonHoverColor+
 �� " N��� 5O       �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   �� 5P       � z� 5Q      �� 5R      $
 1.03Q�6-   $
 1.03Q�6;   5T      5U      5W      �� 5Y   
   "  6   .�5Z      ��  �@ 
Foreground 6+   �� *Window.TextColor+�� 5[       � ��$ 0,0,10,0q�6'   5\      �� 5^   
   " 9�6   .�5_      ��  � �� 6+   �� *Window.TextColor+�� 5`       � ��$ 22(�6)   �� 5a       �@9�ExpandDirection$
 Down=�60   �� 5b       �@9�
IsExpanded .  6+   5c      �� 5e   
   " ��6   .�5f      ��  � ��
 ���� 6+   �� 5g       � ��$ 0q�60   �� 5h       � ��$ 10,0,0,0q�6'   5i      �� 5k   
   " ��6   .�5l      ��  � �� 6+   �� *Window.TextColor+
 �� " N��� 5m       � ��$ 18(�6)   �� 5n       � ��$ Center=�69   5o      �� 5q   
   " 	�6   .�5r      ��  � �� 6+   �� *Window.TextColor+�� 5s       � ��$ 18(�6)   �� 5t       � ��$ Center=�69   5u      5w      5x      