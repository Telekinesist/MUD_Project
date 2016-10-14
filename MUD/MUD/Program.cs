using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MUD
{
	class Program
	{
		static string input = "";
		static void Main(string[] args)
		{
			//Ads data
			Data.addCommands();
			Data.addData();
			Data.createWorld();
			Data.door.Play();
			
			Thread.Sleep(8400);
			Console.WriteLine(@"              :,.  ::  ii,   :1@0f   @@;  --          @@.   ;0@L;    ,:  .                  
  C@@tCCG0t .iLLGft1   iiiC8L             ;,,    :,,             G@@@;      ;8  ii         
81     .f0f       ;  :C0Lf       ,.8@@@@@@@@@@@@@@@@@@@0L;ii.          .L:                   
                 1 t       :i8@@@@@@@@8CCCCCL;, G0CCCCCC@@@@@@@@@@@;,      G:       i.      
.               ;i     ;@@@@@@@Gi     ,;;;L@@@@@@@@@@@;; ;   ,00@@@@@@L.     t0,     .      
             ,0     ,t@@@@C   .iC@@8@@@8@G@@tC G00@@@@@@@@8@@@@;:   G@@@@G;.   .0L     ,    
,          ,0    :1L@@G   ;@@@@@@C@@0@@@. t@iC  Cf@8@f1@@L@@@@@8@@@C:  :8@@@@f   iCL        
         ,t   ,L@@@@1 ,@@G@@@@@@@@t@G@@@  t@,f  1t@f@1 @@@8@1@@@8@@@@@@tiG8@@@@@    it.     
        .,   i@@GC8L8@@@@@0@@@@1 t@GC1@8  @@11 ,@,@@@t08t0@t @ft G8@@@@@@f@@,i0@t    ;8;    
       .t   .fG, @@@@@@@@@@8@ C..f@t  GGGCGG11 :@1G. :G1; G80@,t @@@@@@@@@@@@if .     f;  ; 
  , . ,8     1 i0@@@@@0C@@8f001                 ,               Gf@@@@@GG@@@@@C i.    t@i  t
      tt   ;,itt@@@@@@@@@8;           .               .,,.          0@@@@@@@@@@G Cf    8G1 f
      t1   tC :0@@@@1i       .:Li 8C:,@t  t     , t  tt0@t@ 818t,     .t8t@@@@L: i@t   fC,. 
     ,tt   tt  @@@@@t...  t@ft t  t0:t@t        L t  tt0@@@ t  t@@8 ..;tC@@@@@@  @@L    f   
      @    t@t @@@@@@@@@8@@@@t t  @t  @t  i     i t  ti@@@L t  t@@@@@G@@@@@@@@t. @@t    @   
      @.   0@1;@@@@@@0@t @f@@t t  tt  @t  f       t LttG@;0 1  t@@@@@.G0@@@@@@@; G@0  C8@f .
      @     tttL@G@@@@@C @@@0t f  LL G@t  1       t  tttt10 t  t@@@0G @@@@@@@@t  @@8    tt 1
      t    t@tt@@@@@@G@@ @@@@t t  fG ;@f  L       t  tttttf i   00@@Ct@@@@@@@@@@ @@@,   t@  
.    ti   t@@tL@@@@@@ t@t@G@1t t  tCtt@8  @,    ; 8tC@tf .@ t  ;@@@@@t@t;@@@@@@; @@@t   t@t 
     t1   t@@t@@@@@@0 L@@@t11Lf@C               ,           .8@@@@@@@@@8 @@@@@@@t@@@f   t@@ 
     @f.  .@@t@@@@@@@GG@@@tt                    ,                .@@@@@88@@@@@@@;@@@t,   f@1
     f    :@@tC0@@@@@L,,,.       :00  t@if@@     .@@@@@  100        ,,:18@@@@@@1.8@@@    G@t
    ,t    t@0C@@@@@@@,,     :8@@... 8.i@  t     L t :@t  f t ;@@8.     tt@@@@@@@8@@@@    tt 
    t:    t@@@8@@@@@@@@8@0@8 f8@  , L  t  t     i t ,@.;tt t :8@tt@@0@@@@@@@@@@@0@@@@1   ,t 
    1.   CG@@@@@@@@@@@@tL@@808@@. t tt:it i     t t t@.;@t ; t@@G8@@@LL@@@@@@@@@@@@@@   i@8 
    G    8@@@80@@@f@@1@t.ti@8f@@. t t@,GC :    ;0 t ttC0@. t t@@@8@1f t@C@@@@@@8@@@@@:   t@t
   tt    G@@L@@@@@@@@ @G t.@L0t@. t t@@@@ ;    1@ t t; t@  t t@t@t@.t 8@:@@@@@@@@@@@@    .Lt
   0     @@@@;0@@@@@C.8L@t @@@@@  t i0t@@tt i@ 10 t @8f@@  t t@@@@@ t8G@:0@@@@@@GC@@@0i    @");

			Console.ReadLine();
			Data.door.Stop();

			//While loop narrates the story, takes player input, and handles it
			while (!(input.Equals("exit")))
			{
				Narrator.enterRoom(Data.room());
				input = Console.ReadLine().ToLower();
				Interface.playerCommand(input);
			}
		}
	}
}
