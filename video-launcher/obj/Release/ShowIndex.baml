   M S B A M L   `   `   `  ���� I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher      video_launcher.ShowIndex   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:video_launcher     W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/    N� Title$  	ShowIndex�� � 	Resources     BooleanToVisibilityConverter.  (video_launcher.StringVisibilityConverter  StringToVisibilityConverter/  )video_launcher.WatchedVisibilityConverter   WatchedToVisibilityConverter �� 
TargetType  
ShowButton �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value
 �� RelativeSource �� AncestorType �� ScaleX �� ScaleY �� Padding��%�  &	        &	      &	 
     &	      '�� %    ��     �� " ��.���  � ��
 ���� ��  � ��
 �������  � �� �� " ��.R��� #��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver	 . . ���  � �� �� *Window.ButtonHoverColor+
 �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.03Q�$
 1.03Q�P�  �@J�	IsFocused	 . . ���  � �� �� *Window.ButtonHoverColor+
 �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.03Q�$
 1.03Q��� " ��.���  � �� �� *Window.ButtonColor+��  � �� �� *Window.TextColor+��  � ��$ 40����  � ��$ 18(���  � ��$
 Bold"���  � ��$ 10q���  � �� �� " ��.R��� #��z��$ 15��$ 10q�._��� $��Center=�$
��10,0q� P�  �@J�IsMouseOver	 . . ���  � �� �� *Window.ButtonHoverColor+
 �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.05Q�$
 1.05Q�P�  �@J�	IsFocused	 . . ���  � �� �� *Window.ButtonHoverColor+
 �� " N���  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $
 1.03Q�$
 1.03Q�.��]� ��. .+�� $	��Top=� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   .���  �� $��* ��� $
��Auto �.+�  FontAwesome5.SvgAwesome     Icon$ 
Solid_Home=�$
��10,0q�   
Foreground �� *Window.TextColor+�� $��1��$
��Home��$��Center=����� *Window.TextColor+�� $��50(�$��1�� �� TextAlignment$ Center=�$
��Bold"����� *
ShowType+���� *Window.TextColor+�� -   $��	btRefresh��$��2��.���  �� $��* ��� $
��Auto �.+�  $ Solid_CircleNotch=�$
��10,0q� �� *Window.TextColor+�� -   $��	tbRefresh��$��1��$��Reload��$��Center=����� *Window.TextColor+9� -   $��	exFilters��$
��Left=� 9� ExpandDirection$ Right=�$
��Left=�$��Stretch=�$��22(�$	��200������ *Window.TextColor+���� $��Filters�� � LayoutTransform ��  �� Angle$	 -90Q�.���� $
��Auto=�.���� $��0,10,0,0q�.+��� -   $��tbSearch��9� -   $��exGenres��$��Genres��$
 Down=� 9� 
IsExpanded .  $��22(����� *Window.TextColor+.���� 
������ $��0q�$��10,0,0,0q����� *
ShowGenres+���� .R��� -   $��18(�$��Center=� d� 	IsChecked �� *	IsChecked+ �� Mode$ TwoWay=����� *Name+���� *Window.TextColor+
 �� " N�9� -   $��	exWatched��$��Watched��$
 Down=� .  $��22(����� *Window.TextColor+.���� 
������ $��0q�$��10,0,0,0q�.@�	� -	   $��rbAllWatched�� 	� 	GroupName$ 
rbgWatched��$	��All��$
 TrueY�$��18(�$��Center=����� *Window.TextColor+
 �� " N�	� -
   $��rbInProgress��$ 
rbgWatched��$��In Progress��$��18(�$��Center=����� *Window.TextColor+
 �� " N�	� -   $��rbUnwatched��$ 
rbgWatched��$��	Unwatched��$��18(�$��Center=����� *Window.TextColor+
 �� " N�	� -   $��	rbWatched��$ 
rbgWatched��$��Watched��$��18(�$��Center=����� *Window.TextColor+
 �� " N��� -   $��Reset Filters��$
��Left=��� -   $��lvShows�� �� SelectionMode$ Single=�$��Disabled=�
������ $��10,0,0,0q�$��0q����� *FilteredShows+���� " ��.���  � �� �� " ��.R��� ��  � |� .  ���� .R�� $��Center=����� .R��� -   $��5q�
�������$��0q�#��[  � ContextMenu �� .@�m�  m� Command �� *CommandToggleWatched+���� *WatchedToggleText+ m� Icon   
 � � � �� *WatchedContextIcon+y��� *
File_nfo+ �� 	Converter# [ .��]� $	��185��$	��278����.  $��10q�����  j� Stretch$
 Fill=�  �� ImageSource  �� *
Img_poster+.+��� .+�  
! �� Top$! 10��" �� Left$	" 155��
 � � �$��20��# � ToolTip$# Watched�� �� *WatchedIcon+y��� *	Watched+# [ �� $��Bottom=�$
��Wrap=�$��Stretch=�$ Center=�$��24(�$��0,0,0,10q����� *DisplayName+���� $ �� Color$$ Black��% �� Opacity$	% 0.7Q�