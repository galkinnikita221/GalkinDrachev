   M S B A M L   `   `   `  ����Q  MWeather_drachev_galkin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Weather_drachev_galkinWeather_drachev_galkin  5   	   '    !Weather_drachev_galkin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6local$clr-namespace:Weather_drachev_galkin     5   	   -   5          � Title$!  Прогноз погоды��5   	   $	��500��6    $	��800��6-   .��5      � ���#F0F4F8.+�5   
   �� -   5         ��Name$ CityTextBox��5      $	��250��6'   $��35��63   $��10q�6?   $	��Top=�6K   $
��Left=�5      $��16(�5	      ���#2196F3$��2q�66   �� 5   
   -   5        $#��Обновить погоду��5      $	��150��6+   $��35��67   $��
270,10,0,0q�6C   $	��Top=�5      $
��Left=�6)   ���#2196F3
�������$��14(�5   9   $��0q�5       � Cursor$
 Hand��6%   63   �� 5   
   -   5         ��Name$ RequestCountTextBlock��5      $	��250��63   $��30��6?   $��10q�6K   $	��Top=�5      $��Right=�6,   $��14(�5      ���#444 �� TextAlignment$ Right=�64   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ WeatherDataGrid��5         AutoGenerateColumns .  $��Stretch=�5      $��Stretch=�61   $��10,100,10,10q�5         HeadersVisibility$ Column=�6)      GridLinesVisibility$
 None=�6D   	   RowBackground	 �#FAFAFA
   AlternatingRowBackground
 �#F0F0F0���#DDD$��1q�5   a      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата и время��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
DateTime+6X     5      $ Температура��6%   $	 100 6Z    6:   �� *Temperature+6Z     5      $ Давление��6%   $	 100 6T    67   �� *
Pressure+6T     5      $ Влажность��6%   $	 100 6U    68   �� *
Humidity+6U     5      $ 
Ветер��6%   $	 100 6R    64   �� *	WindSpeed+6R     5      $ Ощущается как��6%   $	 120 6Z    6<   �� *	FeelsLike+6Z     5      $ Описание��6%   $	 150 6^    67   �� *WeatherDescription+6^   5!      5"      5#      