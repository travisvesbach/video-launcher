   M S B A M L   `   `   `  ���� I  Evideo-launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:video_launchervideo_launcher      video_launcher.Home   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:video_launcher     W SFontAwesome5.Net, Version=2.0.8.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/    N� Title$
  Home�� � 	Resources .  (video_launcher.StringVisibilityConverter   StringToVisibilityConverter �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� Triggers P� Property	 P� Value
 �� ScaleX �� ScaleY��%j  &	        '��        �� " ��.���  � �� �� *Window.ButtonColor+��  � �� �� *Window.TextColor+��  � ��$ 24(���  � �� �� " ��.R��� #��z��$
 10,5q�$��20, 10q�$	��400��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver	 . . ���  � �� �� *Window.ButtonHoverColor+��  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $

 1.05Q�$
 1.05Q�P�  �@J�	IsFocused	 . . ���  � �� �� *Window.ButtonHoverColor+��  �@J�RenderTransformOrigin$ 0.5, 0.5&���  � z� �� $

 1.05Q�$
 1.05Q�.���  � RowDefinitions �� $��* ��� $
��Auto ��� $��* �.+�� $��1��$��Center=�.+��� -   $	��250��$	��300��y��� *AnimeDirectory+ �� 	Converter# [   ��%:   '��       �� " ��.���  �@��CornerRadius$ 15��.��]� $��15q�.+��� $��Bottom=� �� TextAlignment$ Center=�$��30(�$
��Bold"�$��Anime��� $��Center=�$��15q�.+�  FontAwesome5.SvgAwesome     Icon$ Solid_PhotoVideo=�   
Foreground �� *Window.TextColor+�� -   $	��250��$	��300��y��� *MovieDirectory+# [   ��%:   '��       �� " ��.���  �@��CornerRadius$ 15��.��]� $��15q�.+��� $��Bottom=�$ Center=�$��30(�$
��Bold"�$��Movies��� $��Center=�$��15q�.+�  $ 
Solid_Film=� �� *Window.TextColor+�� -   $	��250��$	��300��y��� *TVShowDirectory+# [   ��%:   '��       �� " ��.���  �@��CornerRadius$ 25��.��]� $��15q�.+��� $��Bottom=�$ Center=�$��30(�$
��Bold"�$��TV Shows��� $��Center=�$��15q�.+�  $ Solid_TV=� �� *Window.TextColor+�� $��2��.+��� -    �� Bottom$ 10�� �� Left$ 10�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.��� .+�  $ 
Solid_Cogs=�$��20��$	��5,0q� �� *Window.TextColor+�� $ Center=�
Settings