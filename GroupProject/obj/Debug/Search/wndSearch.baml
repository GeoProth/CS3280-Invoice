   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GroupProject.SearchGroupProject.Search  5   	   #    GroupProject.Search.wndSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GroupProject.Search     5   	     � Title$  Search��5   	   $	��450��6   $	��800��6%    � Icon$ ../Images/search.png��61    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���	#FF404854.+�5   
   �� -   5         ��Name$ SelectInvoiceBtn��5      $��Select Invoice��6+   $
��Left=�6D   $��369,364,0,0q�6_   $	��Top=�6t   $��95��6�   {�.  $��34��6�    J� RenderTransformOrigin$ 0.476,0.635&�6�   
���   �$��Segoe UI Semibold)�6  $��14(�6*  
���   �68  �� 5   
   -   5        $ 	CancelBtn��5      $��Cancel��6$   $
��Left=�65   $��
46,364,0,0q�6P   $	��Top=�6d   $��95��6|   $��34��6�   
���   �$��Segoe UI Semibold)�6�   $��14(�6�   �� 5   
    �� Orientation$ Vertical=�6   $��46,10,482.6,349q�6,   .+�5      �� $��Invoice Number��6   $��-3,0,113.8,0q�6-   $��Segoe UI Semibold)�6C   $��16(�6b   ���	#FFFCFBFB6p   �� 5      -   5         ��Name$ InvoiceNumComboBox��5      $
��Left=�63   $	��Top=�6N   $	��120��6f   $��26��6�   5      �� 5   
   $ Vertical=�6   $��185,10,327.6,349q�6,   .+�5      �� $��Invoice Date��6   
�������$��16(�6>   $��Segoe UI Semibold)�6L   $��0,0,116.8,0q�6k   �� 5      -   5        $ InvoiceDateComboBox��5      $
��Left=�64   $	��Top=�6O   $	��164��6g   $��26��6�   5      �� 5   
   $ Vertical=�6   $��369,10,192.6,349q�6,   .+�5      �� $��Invoice Total��6   
�������$��Segoe UI Semibold)�6?   $��16(�6^   $��0,0,103.8,0q�6l   �� 5      -   5        $ InvoiceTotalComboBox��5      $
��Left=�65   $	��Top=�6P   $	��133��6h   $��26��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 InvoiceListBox��5      $��Stretch=�6+   $	��263��6P   $��
46,76,45,0q�6]   $	��Top=�6q   
   AutoGenerateColumns
 .     SelectionMode$ Single=�5         CanUserResizeRows .     
IsReadOnly .    CanUserAddRows .  $��Segoe UI Semibold)�6�   $��14(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Invoice Number��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 .3* 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$ InvoiceNumber�6d     5      $ Invoice Date��6%   $	 .4* 6a    6<   �� $ InvoiceDate�6a     5       $ Invoice Total��6%   $	 .3* 6_    6<   �� $ 	TotalCost�6_   5"      �� 5#   
   -   5        $ ClearFilterBtn��5#      $��Clear Filters��6)   $
��Left=�6A   $��
606,34,0,0q�6\   $	��Top=�6p   $��89��6�   {�.  $��32��6�   
���   �$��Segoe UI Semibold)�6�   $��14(�6   5%      5&      