   M S B A M L   `   `   `  ���� I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher  !    video_launcher.ShowEpisodes   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:video_launcher     W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/    N� 
Foreground
  ����� N� Title �� *ShowData.DisplayName+ � 	Resources ,   &video_launcher.NullVisibilityConverter   NullToVisibilityConverter.  (video_launcher.StringVisibilityConverter  StringToVisibilityConverter   BooleanToVisibilityConverter/  )video_launcher.WatchedVisibilityConverter   WatchedToVisibilityConverter �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value �� RelativeSource �� AncestorType �� ScaleX �� ScaleY  EpisodeButton��%�  &	        &	      &	 
     &	      '��      &	 �        ��   �� " ��.���  � �� �� *Window.ButtonColor+��  � �� �� *Window.TextColor+��  � ��$ 40����  � ��$ 18(���  � ��$
 Bold"���  � ��$ 10q���  � �� �� " ��.R��� #��z��$ 15��$ 10q�._��� $��Center=�$
��10,0q�	 P� 
 �@J�IsMouseOver . . ���  � �� �� *Window.ButtonHoverColor+ �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.05Q�$
 1.05Q�P� 
 �@J�	IsFocused . . ���  � �� �� *Window.ButtonHoverColor+ �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.03Q�$
 1.03Q��� " ��.���  � ��
 ���� ��  � ��
 �������  � �� �� " ��.R��� #��z��$ 15��$ 10q�._��� $��Center=�$
��20,0q�	 P� 
 �@J�IsMouseOver . . ���  � �� �� *Window.ButtonHoverColor+ �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&�P� 
 �@J�	IsFocused . . ���  � �� �� *Window.ButtonHoverColor+ �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&�.��� ����  j� Stretch$ UniformToFill=� �� ImageSource �� *ShowData.Thumb+.+�� ����  �� Color$ Black�� �� Opacity$	 0.8Q� � RowDefinitions �� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�� $��3�� �� $
��Auto ��� $��* �.+��� -   .���  �� $��* ��� $
��Auto �.+�  FontAwesome5.SvgAwesome     Icon$ Solid_Backward=�$
��10,0q�   
Foreground �� *Window.TextColor+�� $��1��$��Center=� �� TextAlignment$ Center=�About�� $��1��$��50(�$ Center=�$
��Wrap=�$
��Bold"����� *ShowData.DisplayName+�� $��1��$
��Auto=�$��Center=�$��20q�$
��10,0q�.���� 
������ $��0q����� *	Seasons+���� .R��� -   #��[ .���� $��18(�$��Center=����� *Name+�� $��1��$��1��$��2��$��Center=�$
��Auto=�$
��10,0q�.���� 
������ $��0q����� *FilteredEpisodes+���� .R��� -   #��[  � ContextMenu �� .@�m�  m� Command �� *CommandToggleWatched+���� *WatchedToggleText+ m� Icon   
 � � � �� *WatchedContextIcon+y��� *
File_nfo+ �� 	Converter# [  J� InputBindings d�  d� Gesture$ LeftDoubleClicka� �� Command �� *CommandPlay+.���  �� $��30 ��� $��40 ��� $��* �.+�  
  �� Top$  10��! �� Left$	! 155��
 � � �$��20��" � ToolTip$" Watched�� �� *WatchedIcon+y��� *	Watched+# [ �� $��1��$��18(�$
 Left=����� *EpisodeNumberString+�� $��2��$��18(����� *DisplayName+� $��2��$��3��$��2��$��15q�y��� *SelectedEpisode+# [   �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $��Center=�$��30(�$
��Wrap=����� *SelectedEpisode.DisplayName+�� $��1��$��15,0,0,0q�$	��300������ *SelectedEpisode.Thumb+�� $��2��$
��Auto=�.���� $
��Wrap=�$��18(�$��15q�$ Center=����� *SelectedEpisode.Plot+� $��3��$��10q� �� $��* ��� $��* �.+��� $��16(�y��� *SelectedEpisode.Aired+# [ �� $�Aired:��
����� � �� ��� *SelectedEpisode.Aired+�� $��2��$��16(�$��Right=�y��� *#!SelectedEpisode.LastWatchedString+# [ �� $�Last Watched:��
����� � �� ��� *#!SelectedEpisode.LastWatchedString+� $��4��.+��� ���� *SelectedEpisode.CommandPlay+.���  �� $��* ��� $
��Auto �.+�  $ 
Solid_Play=�$
��10,0q� �� *Window.TextColor+�� $��1��$��Center=�Play