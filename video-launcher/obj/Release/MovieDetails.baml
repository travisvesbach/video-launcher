   M S B A M L   `   `   `  ���� I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  !    video_launcher.MovieDetails   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:video_launcher     W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  -     N�Name$  MovieDetailsPage�� N� 
Foreground
 ����� N� Title �� *MovieData.DisplayName+ � 	Resources ,   &video_launcher.NullVisibilityConverter   NullToVisibilityConverter.  (video_launcher.StringVisibilityConverter  StringToVisibilityConverter   BooleanToVisibilityConverter �� 
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
 1.03Q�.��� ����  j� Stretch$ UniformToFill=� �� ImageSource �� *MovieData.Thumb+.+�� ����  �� Color$ Black�� �� Opacity$
 0.45Q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� $	��Top=� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   .���  �� $��* ��� $
��Auto �.+�  FontAwesome5.SvgAwesome     Icon$ Solid_Backward=�$
��10,0q�   
Foreground �� *Window.TextColor+�� $��1��$��Center=�Movies�� $��1��$��50(� �� TextAlignment$ Center=�$
��Wrap=�$
��Bold"����� *MovieData.DisplayName+�� $��2������ * MovieData.CommandToggleWatched+ � ToolTip �� *MovieData.WatchedToggleText+y��� *MovieData.File_nfo+ �� 	Converter# [ .���  �� $��* ��� $
��Auto �.+�  $
��10,0q� �� *MovieData.WatchedIcon+ �� *Window.TextColor+�� $��1������ *MovieData.WatchedButton+�� $��1��$��300,0q�$��24(�$ Center=����� *MovieData.OriginalTitle+y��� *MovieData.OriginalTitle+# [ �� $��2��$��300,0q�$
��Wrap=�$��24(�$ Center=����� *MovieData.Tagline+y��� *MovieData.Tagline+# [ � $��3��$
��0,15q� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��15,0,0,0q����� *MovieData.Img_poster+�� $��1��$��2��$
��Auto=����� $ Black��$	 0.6Q�.���� $��20(�$
��Wrap=�$
��15,0q� �� Padding$ 10q�$��Disabled=����� *MovieData.Plot+�� $��3��$��2��$��16(�$
��15,0q�$��10q����� $ Black��$	 0.6Q�.@��� $
��Wrap=�y��� *MovieData.Director+# [ �� 
����� �$�	Director:�� �� ��� *MovieData.Director+�� $
��Wrap=�y��� *MovieData.Country+# [ �� 
����� �$�Country:�� �� ��� *MovieData.Country+�� $
��Wrap=�y��� *MovieData.Studio+# [ �� 
����� �$�Studio:�� �� ��� *MovieData.Studio+�� $
��Wrap=�y��� *MovieData.GenreString+# [ �� 
����� �$�Genre:�� �� ��� *MovieData.GenreString+�� $
��Wrap=�y��� *MovieData.Set+# [ �� 
����� �$
�Set:�� �� ��� *MovieData.Set+�� $
��Wrap=�y��� *MovieData.Runtime+# [ �� 
����� �$�Runtime:�� �� ��� *MovieData.Runtime+
 minutes�� $
��Wrap=�y��� *MovieData.SubtitlesString+# [ �� 
����� �$�
Subtitles:�� �� ��� *MovieData.SubtitlesString+�� $
��Wrap=�y��� *MovieData.LastWatchedString+# [ �� 
����� �$�Last Watched:�� �� ��� *MovieData.LastWatchedString+� $��4��$��15q�.+��� ���� *MovieData.CommandPlay+.���  �� $��* ��� $
��Auto �.+�  $ 
Solid_Play=�$
��10,0q� �� *Window.TextColor+�� $��1��$��Center=�Play�� ���� *MovieData.CommandOpenTrailer+y��� *MovieData.Trailer+# [ .���  �� $��* ��� $
��Auto �.+�  $ 
Solid_Tape=�$
��10,0q� �� *Window.TextColor+�� $��1��$��Center=�	Trailer