   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GroupProject.ItemsGroupProject.Items  5   	   !    GroupProject.Items.wndItems   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GroupProject.Items     5   	     � Title$  
Items List��5   	   $	��450��6   $	��800��6)    � Icon$ ../Images/items.jpg��65    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���	#FF404854 � RowDefinitions 5   
   �� 5      $
��243* �6   �� 5      $
��113* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ItemListBox��5      $
��Left=�6(   $	��266��6C   $��
157,13,0,0q�6P   $	��627��6d   $	��Top=�6p      AutoGenerateColumns .     SelectionMode$ Single=�5      	   CanUserResizeRows	 .  
   
IsReadOnly
 .    CanUserAddRows .  $��Stretch=�6m   $��16(�6�   $��Segoe UI Semibold)�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        colCode��,  &System.Windows.Controls.DataGridColumn   Header$ 	Item Code��5   7      Width5  /System.Windows.Controls.DataGridLengthConverter$
 .25* 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   ��  �� Path$ ItemCode�6m     5      $ Item Description��6%   $	 .5* 6i    6?   �� $ ItemDescription�6i     5      $ 	Item Cost��6%   $
 .25* 6[    68   �� $ ItemCost�6[   5      �� 5   
   $��0,13,651.6,135.4q�6   .+�5      �� -   5         ��Name$ 
AddItemBtn��5      $��Add Item��6)   $��40��6U   $��	0,0,0.4,0q�6a   $��Segoe UI Semibold)�6t   $��16(�6�   �� 5      -   5        $ EditItemBtn��5      $��	Edit Item��6*   $��40��6X   $��	0,0,0.4,0q�6d   $��16(�6w   $��Segoe UI Semibold)�6�   �� 5      -   5        $ DeleteItemBtn��5      $��Delete Item��6,   $��	0,0,0.4,0q�6^   $��40��6q   $��Segoe UI Semibold)�6}   $��16(�6�   5      � 5   
   $
��Left=�6   $	��113��6*   $	��Top=�67   $	��627��6O   $��157,286,0,0q�6[   $��2��6p    � ColumnDefinitions 5      �� 5       $
��150* �6#   �� 5!      $
��241* �6#   �� 5"      $
��142* �6#   �� 5#      $��0* �6#   .+�5%      �� $��0��6   $��40,0,45.8,43q�6)   $��91��6?   .+�5&      �� $��	Item Code��6   
�������$��16(�6?   $��Segoe UI Semibold)�6M   �� 5'      -   5         ��Name$ ItemCodeBox��5'      $��33��6/   {�.  
�������$��	0,0,0.2,0q�6`   $��Segoe UI Semibold)�6s   $��16(�6�   ���	#FF6060606�   5(      �� 5)      $��1��6   $��42.2,-1,39,43q�6*   $	��202��6A   .+�5*      �� $��Item Description��6   
�������$��16(�6F   $��Segoe UI Semibold)�6T   �� 5+      -   5        $ ItemDescriptionBox��5+      $��33��66   {�.  
�������$��
0,0,-0.4,0q�6g   $��Segoe UI Semibold)�6{   $��16(�6�   ���	#FF6060606�   5,      �� 5-      $��2��6   $��38,0,37.2,41q�6)   $��92��6?   .+�5.      �� $��	Item Cost��6   
�������$��16(�6?   $��Segoe UI Semibold)�6M   �� 5/      -   5        $ ItemCostBox��5/      $��34��6/   {�.  
�������$��Segoe UI Semibold)�6`   $��16(�6   ���	#FF6060606�   50      �� 51      -	   5        $ SaveItemBtn��51      $��	Save Item��6*   $��1��6>   $
��Left=�6N   $��95.2,70,0,0q�6i   $	��Top=�6~   $��97��6�   $��41��6�   $��16(�6�   $��Segoe UI Semibold)�6�   
���   �6�   52      �� 53   
   -
   5        $ BackBtn��53      $
��Back��6"   $
��Left=�61   $��
10,162,0,0q�6L   $	��Top=�6`   $	��132��6x   $��49��6�   
���   �$��16(�6�   $��Segoe UI Semibold)�6�   �� 54   
   $��Close��6   $
��Left=�6!   $��	10,62,0,0q�6<   $	��Top=�6O   $	��132��6g   $��48��6s   $��16(�6   $��Segoe UI Semibold)�6�    �� IsCancel . $��1��6�   55      56      