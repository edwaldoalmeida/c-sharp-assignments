   M S B A M L   `   `   `  ����D  @WpfApp100, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfApp100	WpfApp100  5   	       WpfApp100.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfApp100     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         WpfApp100.AdultParty   Schedule  WpfApp100.MyConverter  myConverter!  WpfApp100.PartyDayConverter  partyDayConverter!  WpfApp100.RowColorConverter  rowColorConverter$  WpfApp100.AllFieldsOkConverter  allFieldsOkConverter��%�   &	        &	      &	 &     &	 9     &	 L       5
   
   6     5   
   6     5   
   6"     5   
   6"     5   
   6%   5      .��5      �  � DataContext# �   6   .+�5   
   � $
��Left=�6   $	��402��6*   $��	10,10,0,0q�67   $	��Top=�6J   $	��775��6b   .+�5      �� $��(between 1 and 31)��6   $
��Left=�61   $��
70,211,0,0q�6L   $	��Top=�6`   $	��123��6x   
����������	#FF2484216�   �� 5      ���	#FFF4F4F5$
��Left=�6)   $��49��6D   $��	0,276,0,0q�6P   
���   �$	��Top=�6r   $	��298��6�    J� Opacity$	 0.5Q�6�   �� 5      ���	#FFF4F4F5$
��Left=�6)   $��51��6D   $��	0,325,0,0q�6P   
���   �$	��Top=�6r   $	��298��6�   $	 0.5Q�6�   �� 5      -   5         ��Name$ textBoxName��5      $
��Left=�6+   $��23��6F   $��	10,33,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��288��6�    J� RenderTransformOrigin$ -0.744,0.413&�6�   $��1��6�   �� 5      $��Customer Name:��6   $
��Left=�6-   $��10,7,0,0q�6H   $	��Top=�6Z   �� 5      $��Average Age:��6   $
��Left=�6+   $��
10,157,0,0q�6F   $	��Top=�6Z   �� 5      $��
Party Day:��6   $
��Left=�6)   $��
10,211,0,0q�6D   $	��Top=�6X   �� 5      -   5         ��Name$ 
buttonSave��5      $
��Save��6)   $
��Left=�68   $��
10,336,0,0q�6S   $	��Top=�6g   $��75��6   $��30��6�    � ToolTip$ Save schedule to a file.��6�   �� 5      -   5        $ buttonRestore��5      $��Restore��6,   $
��Left=�6>   $��
90,336,0,0q�6Y   $	��Top=�6m   $��75��6�   $��30��6�   $# Restore schedule from a file.��6�   �� 5      -   5        $ buttonClearSchedule��5      $��Clear Schedule��62   $
��Left=�6K   $��193,336,0,0q�6f   $	��Top=�6{   $��96��6�   $��30��6�   $6 0Clear schedule from RAM, but it can be restored.��6�   �� 5      -   5        $ buttonClearFields��5      $��Clear Fields��60   $
��Left=�6G   $��193,284,0,0q�6b   $	��Top=�6w   $��96��6�   $��30��6�   6�   �� 5      $��City:��6   $
��Left=�6$   $��	10,61,0,0q�6?   $	��Top=�6R   �� 5       -   5        $ btnClearFilterName��5       $��Clear��61   $
��Left=�6A   $��
472,10,0,0q�6\   $	��Top=�6p   $��45��6�   6�   �� 5!      -   5        $ btnClearFilterCity��5!      $��Clear��61   $
��Left=�6A   $��
624,10,0,0q�6\   $	��Top=�6p   $��41��6�   6�   �� 5#      -   5        $ buttonRegister��5#      $��Register��6-   $
��Left=�6@   $��
10,286,0,0q�6[   $	��Top=�6o   $��75��6�   $��28��6�   	 �� 	IsDefault	 . {�5$      `� 5%      
 `� 	Converter#
 [ 6#   .1�5&      ��  �� ElementName$ textBoxName��6"    �� Path$
 Text�6<   �� 5'      $ textBoxAverageAge��6"   $
 Text�6B   �� 5(      $ textBoxPartyDay��6"   $
 Text�6@   5)      5+      �� 5-      -	   5        $ textBoxAverageAge��5-      $
��Left=�5.      $��23��61   $��
10,183,0,0q�6=   $
 Wrap=�6Q   $	��Top=�6e   $��62��6}   $��3��5/      ��50      �� $ 
AverageAge� �� 	Converter# [  51      �� $ textBoxAverageAge��$) #(Validation.Errors)[0].ErrorContent�.��6r   ��52      �� 53      $ 
AverageAge�6    �� ValidationRules 54        WpfApp100.AverageAgeRule  55      
   Min$ 1��63   
   Max$	 150��6;   57      .��58       59      �� 5;      -
   5        $ textBoxPartyDay��5;      $
��Left=�5<      $��23��61   $��
10,237,0,0q�6=   $
 Wrap=�6Q   $	��Top=�6e   $��62��6}   $��4��5=   <   ��5>      �� $ PartyDay�# [  5?      �� $ textBoxPartyDay��$) #(Validation.Errors)[0].ErrorContent�.��6p   ��5@      �� 5A      $ PartyDay�6    5B        5C      $ 1��63   $ 31��6;   5E      .��5F       5G      &   System.Windows.Controls.DataGrid  5I      -   5        $��theGrid��5J      $
��Left=�5K      $	��307��6,   $��
332,69,0,0q�69   $	��Top=�6M   $	��422��6e      AutoGenerateColumns .     
IsReadOnly . ��5L      �� $ 	PartyList�   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,	  &System.Windows.Controls.DataGridColumn 	  Header$	 Day��6)   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 66   �� *
PartyDay+  5R      $ Customer��6)    6;   �� *CustomerName+  5S      $
 City��6)    67   �� *CustomerCity+  5T      $ 
AverageAge��6)    6=   �� *
AverageAge+   	CellStyle 5W      �� 5X       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5Y      ��  �� Property � �� �� Value 67   �� $ 
AverageAge�# [ 5Z      5]      �� 5_      -   5         ��Name$ ListBoxCities��5_      $
��Left=�6-   $��65��6H   $��	10,87,0,0q�6T   $	��Top=�6g   $	��100��6   ��. $��2��6�   �� 5`      $��Name:��6   $
��Left=�6$   $��	402,7,0,0q�6?   $	��Top=�6R   $��53��6j   �� 5a      $��or��6   $
��Left=�6!   $��
519,33,0,0q�6<   $	��Top=�6P   $��23��6h   �� 5b      -   5        $ txtFilterName��5b      $
��Left=�5d      $��23��61   $��
402,33,0,0q�6=   $
 Wrap=�6Q   $	��Top=�6e   $	��115��6}   $��Eddie��6�   {�5c      �� $ checkBoxFilterBy��$ 	IsChecked�5d   �   �� 5e      -   5        $ txtFilterCity��5e      $
��Left=�5g      $��23��61   $��
545,33,0,0q�6=   $
 Wrap=�6Q   $	��Top=�6e   $	��120��6}   $��	Kitchener��6�   {�5f      �� $ checkBoxFilterBy��$ 	IsChecked�5g   �   �� 5h      -   5        $ 	btnFilter��5h      $��Filter��5j      $
��Left=�6&   $��
679,33,0,0q�6A   $	��Top=�6U   $��75��6m   $��23��6�   {�5i      �� $ checkBoxFilterBy��$ 	IsChecked�5j   �   �� 5k      -   5         ��Name$ checkBoxFilterBy��5k      $��
Filter by:��61   $
��Left=�6F   $��
332,35,0,0q�6a   $	��Top=�6u   6�   �� 5l      $��City:��6   $
��Left=�6$   $��	548,7,0,0q�6?   $	��Top=�6R   $��44��6j   5n      5o      5p      