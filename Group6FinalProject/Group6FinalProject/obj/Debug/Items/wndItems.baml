   M S B A M L   `   `   `  ����M  IGroup6FinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Group6FinalProject.ItemsGroup6FinalProject.Items  5   	   '    !Group6FinalProject.Items.WndItems   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Group6FinalProject.Items     5   	   -   5          � Title$  Items��5   	   $	��450��6   $	��800��6$   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ItemsDataGrid��5
      $
��Left=�6*   $	��399��6E   $��	10,10,0,0q�6R   $	��Top=�6e   $	��399��6}      CanUserReorderColumns .     CanUserResizeRows .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Item Code��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 70 68   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6C   �� *
ItemCode+  5      $ 	Item Name��6%   $		 150 68   
 6D   �� *ItemDescription+  5      $ 
Item Price��6%   $		 100 69   
 6E   �� *	ItemPrice+5      �� 5      -   5         ��Name$ newItemButton��5      $��New Item��6,   $
��Left=�6?   $	��Top=�6Z   $	��102��6r   $��475,294,0,0q�6~   $��24��6�   $
��Bold"�6�   $��14(�6�   6�   �� 5   
   -   5        $ editItemButton��5      $��	Edit Item��6)   $
��Left=�6=   $	��Top=�6X   $	��102��6p   $��475,340,0,0q�6|   $��24��6�   $
��Bold"�6�   $��14(�6�   6�   �� 5   
   -   5        $ deleteItemButton��5      $��Delete Item��6+   $
��Left=�6A   $	��Top=�6\   $	��102��6t   $��475,385,0,0q�6�   $��24��6�   $
��Bold"�6�   $��14(�6�    J� RenderTransformOrigin$ 
0.511,5.18&�6�   �� 5   
   -   5         ��Name$ itemCodeTextBox��5      $
��Left=�6+   $��23��6F   $��475,148,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�    J� 	AllowDrop .   �� 	MaxLength$ 1��6�   6�   �� 5   
   -   5        $ itemCostTextBox��5      $
��Left=�6+   $��23��6F   $��475,266,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�    .  6�   �� 5   
   -   5         ��Name$ itemCodeLabel��5      $��	Item Code��6'   $
��Left=�6;   $��475,117,0,0q�6V   $	��Top=�6k   �� 5   
   -	   5        $ itemCostLabel��5      $��	Item Cost��6'   $
��Left=�6;   $��475,235,0,0q�6V   $	��Top=�6k   �� 5   
   -
   5        $ itemDescLabel��5      $��	Item Name��6'   $
��Left=�6;   $��475,176,0,0q�6V   $	��Top=�6k   �� 5   
   -   5        $ itemDescTextBox��5      $
��Left=�6+   $��23��6F   $��475,207,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   6�   �� 5   
   -   5        $ clearSelectionButton��5      $��Clear Selection��6/   $
��Left=�6I   $	��Top=�6d   $	��102��6|   $��621,340,0,0q�6�   $��24��6�   $
��Bold"�6�   $��14(�6�   6�   5      5      