   M S B A M L   `   `   `  ����A  =lab1_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab1_3lab1_3  5   	       lab1_3.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:lab1_3     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      .+�5   
   ��  J� RenderTransformOrigin$ 0.5,0.5&�6   $��2��65   $��
0,0,-0.4,0q�6I   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ -0.617Q�6$   �� 5      T� 5       T� X$ -2.262Q�6)   5      .@�5      �� $��Products��6   .��5      �  5      �� 5      $
��147* �6+   �� 5      $
��641* �6+   .+�5      �� -   5         ��Name$ labelIdProd��5      $��
Product id��61   $��23,10,24.39,338q�6F   �� 5      -   5         ��Name$ textBoxIdProd��5      $
��Left=�65   $��31��6P   $��	97,10,0,0q�6\    �� TextWrapping$
 Wrap=�6o   $�� ��6�   $	��Top=�6�   $	��178��6�   $��2��6�   �� 5       -   5        $ labelDescrProd��5       $��Description��64   $��23,55,32.39,296q�6J   �� 5!      -   5        $ textBoxDescrProd��5!      $
��Left=�68   $��31��6S   $��	97,55,0,0q�6_   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��178��6�   $��2��6�   �� 5#      -   5        $ labelPriceProd��5#      $��Price��64   $��23,103,38.39,253q�6D   �� 5$      -   5        $ textBoxPriceProd��5$      $
��Left=�68   $��31��6S   $��
97,103,0,0q�6_   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��178��6�   $��2��6�   �� 5&      -   5        $ labelAvailProd��5&      $��Availible amount��64   $��11,153,50.39,203q�6O   �� 5'      -   5        $ textBoxAvailProd��5'      $
��Left=�68   $��31��6S   $��
97,153,0,0q�6_   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��178��6�   $��2��6�   &   System.Windows.Controls.DataGrid  5)      -	   5          Name$ 	usersGrid��5)      $
��Left=�62   $	��150��6M   $��-4,227,0,-49q�6Z   $	��Top=�6p   $	��792��6�   $��2��6�   �� 5+      -
   5        	 ��Name$	 addProd��5+      $	��add��6.   $��185.61,10,324,338q�6<   $��1��6m   6   �� 5,      -   5        $	 dropProd��5,      $��delete��6/   $��185.61,59,324,286q�6@   $��1��6r   �� 5-      -   5        $	 
changeProd��5-      $��Update��61   $��185.61,111,324,234q�6B   $��1��6w   �� 5.      -   5        $	 allProds��5.      $��all products��6/   $��185.61,163,324,188q�6F   $��1��6y   5/      50      �� 51      $��Orders��6   .��52      � .+�53      �� -   5        $ labelIdOrder��53      $��Order id��62   $��23,10,665,338q�6E   $��1��6\   �� 54      -   5        $ textBoxIdOrder��54      $
��Left=�66   $��31��6Q   $��	97,10,0,0q�6]   $
 Wrap=�6p   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 56      -   5        $ labelCustOrder��56      $��Cust_id��64   $��23,55,673,296q�6F   $��1��6]   �� 57      -   5        $ textBoxCustOrder��57      $
��Left=�68   $��31��6S   $��	97,55,0,0q�6_   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 59      -   5        $ labelPriceOrder��59      $
��Repr��65   $��23,103,679,253q�6D   $��1��6\   �� 5:      -   5        $ textBoxReprOrder��5:      $
��Left=�68   $��31��6S   $��
97,103,0,0q�6_   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5<      -   5        $ labelAvailOrder��5<      $��
Total cost��65   $��11,153,691,203q�6J   �� 5=      -   5        $ textBoxCostOrder��5=      $
��Left=�68   $��31��6S   $��
97,153,0,0q�6_   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5?      -   5        $ labelDateOrder��5?      $��	Delivered��64   $��11,194,-11,-194q�6H   (  "System.Windows.Controls.DatePicker  5@      -   5        
  Name$
 textBoxCDayOrder��5@   !   $
��Left=�6;   $��31��6V   $	��Top=�6b   $	��178��6z   $��
97,191,0,0q�6�     5B      -   5        $ usersGridOrder��5B      $
��Left=�67   $	��214��6R   $��-4,227,-6,-3q�6_   $	��Top=�6u   $	��792��6�   $��5��6�   �� 5D      -   5        $	 addOrder��5D      $	��add��6/   $��333,10,324,338q�6=   $��3��6l   6~   �� 5E      -   5        $	 	dropOrder��5E      $��delete��60   $��333,59,324,286q�6A   $��3��6q   �� 5F      -   5        $	 changeOrder��5F      $��Update��62   $��333,111,324,234q�6C   $��3��6v   �� 5G      -   5        $	 	allOrders��5G      $��
all Orders��60   $��333,163,324,188q�6E   $��3��6v   5H      5I      �� 5J      $��	Customers��6   .��5K      �  5L      �� 5M      $	��79* �6+   �� 5N      $
��709* �6+   .+�5P      �� -   5        $ labelIdCustomer��5P      $��Customer id��65   $��23,10,665,338q�6K   $��2��6b   �� 5Q      -   5        $ textBoxIdCustomer��5Q      $
��Left=�69   $��31��6T   $��18.404,10,0,0q�6`   $
 Wrap=�6w   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5S      -   5        $ labelCustCustomer��5S      $��Comp_id��67   $��23,55,673,296q�6I   $��2��6`   �� 5T      -    5        $ textBoxCompCustomer��5T      $
��Left=�6;   $��31��6V   $��18.404,55,0,0q�6b   $
 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5V      -!   5        $ labelPriceCustomer��5V      $��CUST_REP��68   $��23,103,679,253q�6K   $��2��6c   �� 5W      -"   5        $ textBoxReprCustomer��5W      $
��Left=�6;   $��31��6V   $��18.404,103,0,0q�6b   $
 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5Y      -#   5        $ labelAvailCustomer��5Y      $��CREDIT_LIMIT��68   $��11,153,691,203q�6O   $��2��6g   �� 5Z      -$   5        $ textBoxCredCustomer��5Z      $
��Left=�6;   $��31��6V   $��18.404,153,0,0q�6b   $
 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�     5\      -%   5        $ usersGridCustomer��5\      $
��Left=�6:   $	��214��6U   $��-4,227,0,-49q�6e   $	��Top=�6{   $	��792��6�   $��2��6�   �� 5^      -&   5        $	 addCustomer��5^      $	��add��62   $��254.404,10,324,338q�6@   $��1��6v   6�   �� 5_      -'   5        $	 dropCustomer��5_      $��delete��63   $��254.404,59,324,286q�6D   $��1��6{   �� 5`      -(   5        $	 changeCustomer��5`      $��Update��65   $��254.404,111,324,234q�6F   $��1��6�   �� 5a      -)   5        $	 allCustomers��5a      $��all Customers��63   $��254.404,163,324,188q�6K   $��1��6�   5b      5c      �� 5d      $��	SalesReps��6   .��5e      � .+�5f      �� -*   5        $ labelIdSalesReps��5f      $��SalesReps id��66   $��23,10,665,338q�6M   $��1��6d   �� 5g      -+   5        $ textBoxIdSalesReps��5g      $
��Left=�6:   $��31��6U   $��	97,10,0,0q�6a   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5i      -,   5        $ labelCustSalesReps��5i      $
��Name��68   $��23,55,673,296q�6G   $��1��6^   �� 5j      --   5        $ textBoxNameSalesReps��5j      $
��Left=�6<   $��31��6W   $��	97,55,0,0q�6c   $
 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5l      -.   5        $ labelPriceSalesReps��5l      $��OFFICE��69   $��23,103,679,253q�6J   $��1��6b   �� 5m      -/   5        $ textBoxOficeSalesReps��5m      $
��Left=�6=   $��31��6X   $��
97,103,0,0q�6d   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5o      -0   5        $ labelAvailSalesReps��5o      $��Sales��69   $��11,144,691,212q�6I   �� 5p      -1   5        $ textBoxSalesSalesReps��5p      $
��Left=�6=   $��31��6X   $��
97,144,0,0q�6d   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��178��6�   �� 5r      -2   5        $ labelManagerSalesReps��5r      $��Manager��6;   $��11,189,691,167q�6M   �� 5s      -3   5        $ textBoxManagerSalesReps��5s      $
��Left=�6?   $��31��6Z   $��
97,191,0,0q�6f   $
 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��178��6�     5u      -4   5        $ usersGridSalesReps��5u      $
��Left=�6;   $	��214��6V   $��-4,227,-6,-3q�6c   $	��Top=�6y   $	��792��6�   $��2��6�   �� 5w      -5   5        $	 addSalesReps��5w      $	��add��63   $��333,10,324,338q�6A   $��3��6t   6�   �� 5x      -6   5        $	 dropSalesReps��5x      $��delete��64   $��333,59,324,286q�6E   6]   �� 5y      -7   5        $	 changeSalesReps��5y      $��Update��66   $��333,111,324,234q�6G   6`   �� 5z      -8   5        $	 allSalesReps��5z      $��all SalesReps��63   $��333,163,324,188q�6K   6d   5{      5|      �� 5}      $��Offices��6   .��5~      � .+�5      �� -9   5        $ labelIdOffice��5      $��	Office id��63   $��23,10,665,338q�6G   $��1��6^   �� 5�      -:   5        $ textBoxIdOffice��5�      $
��Left=�67   $��31��6R   $��	97,10,0,0q�6^   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5�      -;   5        $ labelCustOffice��5�      $
��City��65   $��23,55,673,296q�6D   $��1��6[   �� 5�      -<   5        $ textBoxCityOffice��5�      $
��Left=�69   $��31��6T   $��	97,55,0,0q�6`   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5�      -=   5        $ labelPriceOffice��5�      $��Region��66   $��23,103,679,253q�6G   $��1��6_   �� 5�      ->   5        $ textBoxRegionOffice��5�      $
��Left=�6;   $��31��6V   $��
97,103,0,0q�6b   $
 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�   �� 5�      -?   5        $ labelAvailOffice��5�      $��Sales��66   $��11,153,691,203q�6F   �� 5�      -@   5        $ textBoxSalesOffice��5�      $
��Left=�6:   $��31��6U   $��
97,153,0,0q�6a   $
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��178��6�   $��1��6�     5�      -A   5        $ usersGridOffice��5�      $
��Left=�68   $	��214��6S   $��-4,227,-6,-3q�6`   $	��Top=�6v   $	��792��6�   $��2��6�   �� 5�      -B   5        $	 	addOffice��5�      $	��add��60   $��333,10,324,338q�6>   $��3��6n   6�   �� 5�      -C   5        $	 
dropOffice��5�      $��delete��61   $��333,59,324,286q�6B   6Z   �� 5�      -D   5        $	 changeOffice��5�      $��Update��63   $��333,111,324,234q�6D   6]   �� 5�      -E   5        $	 
allOffices��5�      $��all Offices��61   $��333,163,324,188q�6G   6`   5�      5�      5�      5�      5�      