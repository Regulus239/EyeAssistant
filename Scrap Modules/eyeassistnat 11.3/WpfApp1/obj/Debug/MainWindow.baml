   M S B A M L   `   `   `  ����^  ZTobii.Interaction.Net, Version=0.7.3.333, Culture=neutral, PublicKeyToken=70326046dcdce6cb\Bclr-namespace:Tobii.Interaction.Wpf;assembly=Tobii.Interaction.NetTobii.Interaction.Wpf  5   	   B >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1 5   	      WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   RtobiiBclr-namespace:Tobii.Interaction.Wpf;assembly=Tobii.Interaction.Net    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5	   	   $��714.2��6   $��928.4��6+   .��5      � -   5         �Name$ MainWindowGrid��5      $
��Left=�6#   $	��616��6>   $��	35,33,0,0q�6K   $	��Top=�6^   $	��878��6v   .+�5   
   � %   Tobii.Interaction.Wpf.Behaviors   IsGazeAware .    GazeAwareMode$ Delayed=�62      GazeAwareDelayTime$	 250Q�6Z   $
��Left=�5      $��350,110,0,0q�6*   $	��Top=�6?   $	��130��6W   $��75��6c   .+�5      �� -   5        $��Email��5      $
��Left=�6%   $	��Top=�6@   $	��130��6X   $��75��6d   $��36(�6�   ��5      �� 5       �� 
TargetType" �6   .�5      -   5        �� 5       �� Property � �� �� Value
 ���� 63    �� Triggers 5      P� 5      	 P� Property	 �@ HasGaze
 P� Value
 . . �5      ��  � ��
 � ���6;   5       5"      5$      � 5%   
    . $ Delayed=�62   $	 250Q�6Z   $
��Left=�5&      $��645,261,0,0q�6(   $	��Top=�6=   $	��180��6U   $��75��6a   .+�5'      �� -   5        $��	Youtube
��5'      $��Center=�61   $��0,0,0,0q�6N   $��Center=�6_   $	��180��6z   $��75��6�   $��36(�6�   ��5(      �� 5)      " �6   .�5+      -   5        �� 5,       � ��
 ���� 63    5-      P� 5.      	 �@ HasGaze
 . . �5/      ��  � ��
 � ���6;   50      52      54      � 55   
    . $ Delayed=�63   $	 250Q�6[   $
��Left=�56      $��345,460,0,0q�6(   $	��Top=�6=   $	��160��6U   $��85��6a   .+�57      �� -   5        $
��EXIT��57      $
��Left=�6$   $��0,0,0,0q�6?   $	��Top=�6P   $	��160��6h   $��85��6t   $��36(�6�   ��58      �� 59      " �6   .�5;      -   5        �� 5<       � ��
 ���� 63    5=      P� 5>      	 �@ HasGaze
 . . �5?      ��  � ��
 � ���6;   5@      5B      5D      � 5E   
    . $ Delayed=�63   $	 250Q�6[   $
��Left=�5F      $��
25,255,0,0q�6(   $	��Top=�6<   $	��185��6T   $��85��6`   .+�5G      �� -   5        $��Notepad��5G      $
��Left=�6'   $	��Top=�6B   $	��185��6Z   $��85��6f   $��36(�6r   6�   ��5H      �� 5I      " �6   .�5K      -	   5        �� 5L       � ��
 ���� 63    5M      P� 5N      	 �@ HasGaze
 . . �5O      ��  � ��
 � ���6;   5P      5R      5T      5U      5W      