   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GroupProject.MainGroupProject.Main  5   	       GroupProject.Main.wndMain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GroupProject.Main     5   	     � Title$  Invoice Manager��5   	   $��491.4��6!   $	��920��60    � Icon$ ../Images/invoice.png��6<    � WindowStartupLocation$ CenterScreen=�5	   
   .��5
      � ���	#FF404854 � RowDefinitions 5   
   �� 5      $
��117* �6   �� 5      $	��61* �6    � ColumnDefinitions 5   
   �� 5      $	��96* �6   �� 5      $
��361* �6   .+�5   
   o� $	��Top=�6   $��Stretch=�6'   $��2��6E   $��24��6Y   $��
0,0,-0.4,0q�6e   .@�5      m� -   5        $��Search Invoice��5      $��24��6/   $��Right=�6;   $��Segoe UI Semibold)�6W   $��14(�6v   6�   m� 5      -   5         m�Name$ ItemListMenu��5      $��Right=�6-   $��	Item List��6I   $��14(�6\   $��Segoe UI Semibold)�6j   $��84��6�   5      �� 5   
   -   5         ��Name$ InvoiceMenuStack��5      $
��Left=�6/   $	��135��6J   $��0,24,0,0q�6W   $	��Top=�6i   $	��192��6�   .+�5      �� -   5         ��Name$ AddInvoiceBtn��5      $��Add Invoice��6,   $��44��6B   $��14(�6j   $��Segoe UI Semibold)�6x   �� 5      -   5        $ EditInvoiceBtn��5      $��Edit Invoice��6-   $��44��6D   $��14(�6m   $��Segoe UI Semibold)�6{   �� 5      -   5        $ DeleteInvoiceBtn��5      $��Delete Invoice��6/   $��44��6H   $��14(�6s   $��Segoe UI Semibold)�6�    �� 	IsDefault . 6�   5      � 5   
   -   5        	 �Name$	 InvoiceDetailGrid��5      $��1��6*   $
��Left=�6:   $	��268��6U   $��	22,25,0,0q�6b   $	��Top=�6u   $	��621��6�    5      �� 5      $	��33* �6    �� 5      $
��134* �6    .+�5!      �� $��
Invoice #:��6   $
��Left=�6)   $	��Top=�6D   $��10,0,0,0q�6\   $��18(�6n   $��Segoe UI Semibold)�6|   ���	#FFFFFEFE6�   �� 5"      -   5        
 ��Name$
 InvoiceNumLbl��5"      $	��TBD��6+   $��98,0,0,0q�69   $	��Top=�6K   $��32��6c   $	��124��6o   $��Segoe UI Semibold)�6{   $��18(�6�   ���	#FFFFFCFC���	#FF606060���	#FFABADB3$
��Left=�6�   �� 5#      -	   5         ��Name$ ItemListBox��5#   )   $��	0,35,7,44q�6      ItemBoxTemplate#��[  6o   ���	#FFA8A7A7$��2��6�   $��2��6�   �� 5$      $��Date:��6   $
��Left=�6$   $��	371,0,0,0q�6?   $	��Top=�6R    J� RenderTransformOrigin$ 1.087,0.809&�6j   
�������$��Segoe UI Semibold)�6�   $��18(�6�   �� 5%      $��Total:��6   $
��Left=�6%   $��63,176.2,0,0q�6@   $	��Top=�6V   $��1��6n   $ -0.927,1.09&�6{   $��Segoe UI Semibold)�6�   $��16(�6�   
�������6�   �� 5&      -
   5        $
 TotalLbl��5&      $
��Left=�6&   $��119,176.2,0,0q�6A   $	��Top=�6X   $��28��6p   $	��120��6|   $�� ��6�   $��1��6�   
�������$��16(�6�   $��Segoe UI Semibold)�6�   �� 5'      -   5         ��Name$ DateBox��5'      $
��Left=�6'   $��23��6B   $��	429,7,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��185��6�   
���   �$��Segoe UI Semibold)�6�   5(      � 5)   
   -   5        $	 NewInvoiceGrid��5)      $
��Left=�6'   $	��139��6B   $	��Top=�6O   $	��660��6g   $��1��6s   $��
22,9.8,0,0q�6�   $ 0.506,0.649&�6�   $��1��6�    5*      �� 5+      $
��303* �6#   �� 5,      $
��356* �6#   .+�5.      �� -   5         ��Name$ ItemComboBox��5.      $
��Left=�6-   $��	37,10,0,0q�6H   $	��Top=�6[   $	��186��6s   $��29��6    �� DisplayMemberPath$ Description��6�   $��Segoe UI Semibold)�6�   $ �� IsSynchronizedWithCurrentItem$ FalseY�6�   ��5/      �� 50       �� EndPoint$	 0,1&�6*    �� 
StartPoint$	 0,0&�69   .��51      �  � Color$ 	#FFC9E9FF��6'    � Offset$ 0Q�69   � 52      $ 	#FF849CAD��6'   $ 1Q�69   53      55      �� 56      -   5        $ CostBox��56      $
��Left=�6'   $��23��6B   $��85.8,10,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��78��6�   {�.  $��1��6�   
�������$ -0.103,0.43&�6�   ���	#FF606060$��$0.00��6  $��Center=�6  $��Center=�6<  $��Segoe UI Semibold)�6^  $��16(�6}  �� 57      $��Cost:��6   $
��Left=�6$   $��
28.8,6,0,0q�6?   $	��Top=�6S   $ -2.729,3.109&�6k   $��1��6�   $��33��6�   $��52��6�   
�������$��16(�6�   $��Segoe UI Semibold)�6�   �� 58      $��	Quantity:��6   $
��Left=�6(   $��
303,58,0,0q�6C   $	��Top=�6W   $��81��6o   $��36��6z   $��2��6�   $��Segoe UI Semibold)�6�   $��16(�6�   
�������6�   �� 59      -   5        $ 
AddItemBtn��59      $��Add Item(s)��6)   $
��Left=�6?   $��
160,80,0,0q�6Z   $	��Top=�6n   $	��100��6�   $��33��6�   $ 0.696,0.579&�6�   $��14(�6�   $��Segoe UI Semibold)�6�   
���   �6  �� 5:      -   5        $ DeleteItemBtn��5:      $��Delete Item��6,   $
��Left=�6B   $��	10,80,0,0q�6]   $	��Top=�6p   $	��100��6�   $��33��6�   $ 0.696,0.579&�6�   $��Segoe UI Semibold)�6�   $��14(�6�   ���	#FF1414146  �� 5;      -   5        $ SaveInvoiceBtn��5;      $��Save Invoice��6-   $
��Left=�6D   $��220.8,80,0,0q�6_   $	��Top=�6u   $	��100��6�   $��33��6�   $ 2.032,0.688&�6�   $��14(�6�   $��Segoe UI Semibold)�6�   
���   �$��1��6'  �� 5<      -   5        $ QuantityBox��5<      $
��Left=�6+   $��23��6F   $��85.8,62,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $��78��6�   {�.  $��1��6�   
�������$ -0.103,0.43&�6�   ���	#FF606060$��0��6  $��Center=�6  $��Center=�6<  $��Segoe UI Semibold)�6^  $��16(�6}  5=      5>      5?      