   M S B A M L   `   `   `  ���� I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher       video_launcher.ShowDetails   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:video_launcher     W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  -     N�Name$  ShowDetailsPage�� N� 
Foreground
 ����� N� Title �� *ShowData.DisplayName+ � 	Resources ,   &video_launcher.NullVisibilityConverter   NullToVisibilityConverter.  (video_launcher.StringVisibilityConverter  StringToVisibilityConverter   BooleanToVisibilityConverter �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding
 �� Triggers P� Property P� Value �� RelativeSource �� AncestorType �� ScaleX �� ScaleY��%�  &	        &	      &	 
     '��          �� �� " ��.���  � �� �� *Window.ButtonColor+��  � �� �� *Window.TextColor+��  � ��$ 40����  � ��$ 18(���  � ��$
 Bold"���  � ��$ 10q���  � �� �� " ��.R��� #��z��$ 15��$	 10q�._��� $��Center=�$
��10,0q�
 P�  �@J�IsMouseOver . . ���  � �� �� *Window.ButtonHoverColor+ �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.05Q�$
 1.05Q�P�  �@J�	IsFocused . . ���  � �� �� *Window.ButtonHoverColor+ �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.03Q�$
 1.03Q�.��� ����  j� Stretch$ UniformToFill=� �� ImageSource �� *ShowData.Thumb+.+�� ����  �� Color$ Black�� �� Opacity$
 0.45Q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��  � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   .���  �� $��* ��� $
��Auto �.+�  FontAwesome5.SvgAwesome     Icon$ Solid_Backward=�$
��10,0q�   
Foreground �� *Window.TextColor+�� $��1��$��Center=�
TV Shows�� $��1��$��50(� �� TextAlignment$ Center=�$
��Wrap=�$
��Bold"����� *ShowData.DisplayName+�� $��2������ *ShowData.CommandToggleWatched+ � ToolTip �� *ShowData.WatchedToggleText+y��� *ShowData.File_nfo+ �� 	Converter# [ .���  �� $��* ��� $
��Auto �.+�  $
��10,0q� �� *ShowData.WatchedIcon+ �� *Window.TextColor+�� $��1��$��Center=����� *ShowData.WatchedButton+�� $��1��$��300,0q�$��24(�$ Center=����� *ShowData.OriginalTitle+y��� *ShowData.OriginalTitle+# [ �� $��2��$��300,0q�$
��Wrap=�$��24(�$ Center=����� *ShowData.Tagline+y��� *ShowData.Tagline+# [ � $��3��$
��0,15q� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��15,0,0,0q����� *ShowData.Img_poster+�� $��1��$��2��$
��Auto=����� $ Black��$	 0.6Q�.���� $��20(�$
��Wrap=�$
��15,0q� �� Padding$ 10q�$��Disabled=����� *ShowData.Plot+�� $��3��$��2��$��16(�$
��15,0q�$��10q����� $ Black��$	 0.6Q�.@��� $
��Wrap=�y��� *ShowData.Director+# [ �� 
����� �$�	Director:�� �� ��� *ShowData.Director+�� $
��Wrap=�y��� *ShowData.Country+# [ �� 
����� �$�Country:�� �� ��� *ShowData.Country+�� $
��Wrap=�y��� *ShowData.Studio+# [ �� 
����� �$�Studio:�� �� ��� *ShowData.Studio+�� $
��Wrap=�y��� *ShowData.GenreString+# [ �� 
����� �$�Genre:�� �� ��� *ShowData.GenreString+�� $
��Wrap=�y��� *ShowData.Runtime+# [ �� 
����� �$�Episode Runtime:�� �� ��� *ShowData.Runtime+
 minutes�� $
��Wrap=�y��� *ShowData.SeasonCountString+# [ �� 
����� �$�Seasons:�� �� ��� *ShowData.SeasonCountString+�� $
��Wrap=�y��� *ShowData.EpisodeCountString+# [ �� 
����� �$�	Episodes:�� �� ��� *ShowData.EpisodeCountString+�� $
��Wrap=�y��� *ShowData.LastWatchedString+# [ �� 
����� �$�Last Watched:�� �� ��� *ShowData.LastWatchedString+� $��4��$��15q�.+��� -   .���  �� $��* ��� $
��Auto �.+�  $ 
Solid_List=�$
��10,0q� �� *Window.TextColor+�� $��1��$��Center=�
Episodes�� ���� *ShowData.CommandOpenTrailer+y��� *ShowData.Trailer+# [ .���  �� $��* ��� $
��Auto �.+�  $ 
Solid_Tape=�$
��10,0q� �� *Window.TextColor+�� $��1��$��Center=�	Trailer