   M S B A M L   `   `   `  ????A  =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistasVistas  5          Vistas.TarjetaPagos   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Vistas     5      -   5          >?Name$  ucPagos??5      $	??141??5   3   
???????
???   ?.??5      ?  J? OpacityMask
 ?   ?$??2,0,0,0q?6   .+?5	   
   ? $??-20,0,669,52q?6   .+?5
      ? $??0,0,0,33q?6   .+?5      ?? -   5         ??Name$ nEmpresa??5      $	??154??6\   $??50??6h   $??24(?6t   $??Center=?6?   $??Center=?6?   $??Center=?6?   ??6*   ?? *	nombreEmp+ ?? TargetNullValue$  ??6?   5      ? 5      $??0,36,0,3q?6   .+?5      ?? -   5        $ rEmpresa??5      $
??Left=?6Y   $??Center=?6t   $??Center=?6?   $	??156??6?   $??43??6?   $??18(?6?   ??6*   ?? *rutEmp+$  ??6?   5      5      ? 5   
   $??127,11,126,20q?6   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ lvPagos??5         CanUserAddRows$ False??6(      AutoGenerateColumns$ False??6?   $   HorizontalScrollBarVisibility$ Hidden=?6[      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
funcionaPo??,  &System.Windows.Controls.DataGridColumn	   Header$	 Estado??5   =   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 80 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   ?? *Estado+ ?? Mode$ TwoWay=?  5      $		 Mes??6)   $	
 100 66    6B   ?? *Mes+  5      $
	 Plan??6)   $
 80 67    6B   ?? *Plan+  5      $	 
Valor Plan??6)   $
 94 6=    6H   ?? *	ValorPlan+  5      $	 Valor Extra??6)   $	
 100 6>    6J   ?? *
ValorExtra+  5      $	 Total??6)   $	
 100 68    6D   ?? *Total+  5      $	 idPag??6)   $	
 100 68    6D   ?? *idPago+  5      $	 idClien??6)   $	
 100 6:    6F   ?? *	idCliente+5      5       ?? 5!   
   $??Center=?6   $	??124??61   
???   ?$	??Top=?6M   $	??800??6e   ?? 5"   
   -   5         ??Name$ btnComprobante??5"      $??Ver Comprobante??6)   $
??Left=?6C   $??
691,46,0,0q?6^   $	??Top=?6r   $	??106??6?   $??21??6?   $??8(?6?   ???	#FF9945E9
???????6?   ?? 5#   
   $??-2,115,-9,-5q?6   $??/pngegg.png??6&   $
??Fill=?6;   ?? 5$   
   $??Generar PDF??6   $
??Left=?6'   $??
706,77,0,0q?6B   $	??Top=?6V   $??11??6n   $??81??6z   ???	#FF9945E9???	#FF9945E9$??8(?6?   ??6?   Z? 6?   ?? 5%   
   -   5        $ btnCambiarEsPag??5%      $y?Visible=?6*   $??Cambiar estado pago??6?   $
??Left=?6]   $	??Top=?6x   $??13??6?   $??82??6?   ???	#FF9945E9???	#FF9945E9$??6(?6?   $??	16,91,0,0q?6?   ??6?   Z? 6  5&      5'      