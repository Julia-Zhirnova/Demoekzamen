   M S B A M L   `   `   `  ����?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRUDCRUD  5          
CRUD.Page1   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:CRUD     5        N� Title$  Page1��5	      .��5      � .+�5   
   �� -   5        $��LViewService��5   !   $��1��6   $��Disabled=�5      $��Center=�5      ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      �� 5       �� Binding 6&   �� *
IsDiscount+ �� Value True6E   .a�5      ��  �� Property � �� �� Value
 ����6;   5      5      ��5      �� 5      .R�5      � $��20q�6   $	��400��6'    � RowDefinitions 5      �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5       $
��auto �6,   6<   �� 5!      $
��auto �6,   6<   .+�5%      �� $��Center=�6?    �� TextAlignment$ Center=�6Z   $	��390��6q   $
��Wrap=�5&   $   $��Center=�68   $
��5 5 q�6U   $��20(�6c   $��1��6q   ��5%   $   �� *	FirstName+5&   �   �� 5'      	 �� Orientation$	 
Horizontal=�6%   $��2��6>   $��Center=�6K   .+�5(      �� $��5 5 5 15q�6W   $��20(�6j   ��6(   �� *Cost+
 �� StringFormat$
 {0:N0}��6z   �� 5)      $��5 5 5 15q�6b   $��20(�6u   ��6(   �� *
LastName+$
 {0:N0} рублей��6�   �� 5*      $��5 5 5 15q�6^   $��20(�6p   ��6(   �� *Phone+$
 за {0} минут��6�   5+      �� 5,      $��3��6[   $��5 5 5 15q�6h   $��Center=�6z   $��14(�6�   ��6$   �� *Email+$
 * скидка {0} %��6�   �� 5-      $��BtnEdit��6!   -   5        $ ��Редактировать��5-   0   $��5��6^   $
��Left=�6k   6�   �� 5.      $��	BtnDelete��63   -   5        $��Удалить��5.   !   $��5��6\   $��Right=�6i   6�   5/      50      53      54      55      