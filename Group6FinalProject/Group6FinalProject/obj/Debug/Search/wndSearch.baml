   M S B A M L   `   `   `  ����M  IGroup6FinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Group6FinalProject.SearchGroup6FinalProject.Search  5   	   )    #Group6FinalProject.Search.WndSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Group6FinalProject.Search     5   	   -   5          �Name$  	wdwSearch��5   	    � Title$ Search��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
      �� -   5         ��Name$ EditInvoiceCanvas��5
      $
��Left=�6(   $	��355��6C   $��	32,40,0,0q�6P   $	��Top=�6c   $	��600��6{   $y�Visible=�6�   .+�5      �� 
���   �$��2q�6#   $
��Left=�67   $	��355��6R   $	��Top=�6_   $	��600��6w   6�   �� 5      -   5         ��Name$ lblInvoiceNum��5      $��Invoice Number:��6%   $
��Left=�6?   $	��Top=�6Z   $
��Bold"�6r   $��14(�6�   
 �� Top$ 4��6�    �� Left$ 2��6�   �� 5      -   5         ��Name$ cboInvoiceNum��5      $
��Left=�6(   $	��Top=�6C   $	��247��6[   $	 125��6g   $ 7��6y   6�   �� 5      -   5        $ lblInvoiceDate��5      $��Invoice Date: ��6&   $
��Left=�6?   $	��Top=�6Z   $
��Bold"�6r   $��14(�6�   $ 3��6�   $ 36��6�   �� 5      -   5        $ cboInvoiceDate��5      $
��Left=�6)   $	��Top=�6D   $	��247��6\   $	 125��6h   $ 39��6z   6�   �� 5      -   5        $ lblTotalCharge��5      $��Total Charge: ��6&   $
��Left=�6?   $	��Top=�6Z   $
��Bold"�6r   $��14(�6�   $ 3��6�   $ 69��6�   �� 5      -   5        $ cboTotalCharge��5      $
��Left=�6)   $	��Top=�6D   $	��247��6\   $	 125��6h   $ 71��6z   6�   �� 5      -	   5         ��Name$ btnClearSelection��5      $��Clear Selection��6*   $
��Left=�6D   $	��Top=�6_   $	��118��6w   $��28��6�   $
��Bold"�6�   $��14(�6�   $��1q�6�   
���   �$	 427��6�   $ 36��6�   6�   &   System.Windows.Controls.DataGrid  5      -
   5          Name$ dgdAllInvoices��5      $	��222��6)   $	 117��66   $	��505��6G   	   GridLinesVisibility$		 All=�6S   $��2q�6m   
   CanUserAddRows
 .  $ 40��6�   5   	   �� 5      -   5        $ lblSelectionHelp��5      $��*Please Make a Selection��6(   $
��Left=�6K   $	��Top=�6f   $
��Bold"�6~   $	 602��6�   $	 243��6�   
���  ��$y�Hidden=�6�   5      �� 5      -   5        $ btnSelectInvoice��5      $��Select Invoice��6'   $
��Left=�6@   $	��Top=�6[   $	��102��6s   $��658,320,0,0q�6   $��24��6�   $
��Bold"�6�   $��14(�6�   $��2q�6�   6�   �� 5      -   5        $ 	btnCancel��5      $��Cancel��6    $
��Left=�61   $	��Top=�6L   $	��102��6d   $��24��6p   $
��Bold"�6|   $��14(�6�   $��658,370,0,0q�6�   6�   5      5      