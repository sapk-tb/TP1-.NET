   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��720��6)   .��5	      � .+�5
   
   ]� .+�5      o� $	��Top=�6   .@�5      m� $	��App��6   .@�5      m� -   5        $
��Quit��5      6-   5      m� 5      $��Demarrer��6   .@�5      m� -   5        $��Ballon��5      6/   m� 5      -   5        $��Premier��5      60   5      m� 5      $��Suppression��6   .@�5      m� -   5        $��Supprimer dernier��5      6:   m� 5      -   5        $��Supprimer dernier ballon��5      6A   m� 5      -   5        $��Supprimer dernier premier��5      6B   m� 5      -   5        $��Supprimer tout��5      67   5      5      5      �� 5   
   -   5         ��Name$ refresh��5      $��Refresh��6"   $
��Left=�64   $��627,393,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -	   5         ��Name$ listBox��5      $
��Left=�6#   $	��305��6>   $	��Top=�6K   $	��712��6c   $��0,83,0,0q�6o   �� 5   
   -
   5        $ startBallonBtn��5      $��Start Ballon��6)   $
��Left=�6@   $��
10,393,0,0q�6[   $	��Top=�6o   $��75��6�   6�   �� 5   
   -   5        $ startPremierBtn��5      $��Start Permier��6*   $
��Left=�6B   $��
90,393,0,0q�6]   $	��Top=�6q   $��75��6�   6�   �� 5   
   -   5         ��Name$ 
pwdTextBox��5      $
��Left=�6&   $��24��6A    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $	��712��6y   {�.  $��0,25,0,0q�6�   �� 5    
   -   5        $ countBallonTextBox��5       $
��Left=�6.   $��24��6I   $
 Wrap=�6U   $	��Top=�6i   $	��341��6�   {�.  $��	10,54,0,0q�6�    � ToolTip$ Ballon Count��6�   �� 5!   
   -   5        $ countPremierTextBox��5!      $
��Left=�6/   $��24��6J   $
 Wrap=�6V   $	��Top=�6j   $	��346��6�   {�.  $��
356,54,0,0q�6�   $ Premier Count��6�   5"      5#      