// See https://aka.ms/new-console-template for more information



using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

int x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0; //aantal geproduceert in normaal werk
int e1 = 0, e2 = 0, e3 = 0, e4 = 0, e5 = 0; //aantal geproduceert in overwerk
int v1 = 0, v2 = 0, v3 = 0, v4 = 0, v5 = 0;     //aantal rest of op voorraad in n maand
int k1 = 0, k2 = 0, k3 = 0, k4 = 0;     //aantal op voorraad voor n maanden

int productiekosten = 100 * (e1 + e2 + e3 + e4 + e5) + k1 * 50 + k2 * 70 + k3 * 85 + k4 * 90; //minimaliseren

//bounds, gehele getallen 
0 =< e1, e2, e3, e4, e5 <= 20
0 <= x1, x2, x3, x4, x5 <= 120 
v1, v2, v3, v4, v5 >= 0; 
k1, k2, k3, k4 >= 0;

//leveringsverplichtingen
v1 = x1 + e1 - 80;
v2 = v1 + x2 + e2 - 120;
v3 = v2 + x3 + e3 - 150;
v4 = v3 + x4 + e4 - 150;
v5 = v4 + x5 + e5 - 130; 

k4 = Math.Min(v1, v2, v3, v4);

k3 = k1_4 + k2_5                  //producten die je 3 maanden op voorraad houd, zijn van maand 1 naar 4 of van maand 2 naar 5. 
k1_4 = Math.Min(v1 - k4, v2 - k4, v3 - k4);
k2_5 = Math.Min(v2 - k4 - k1_4, v3 - k4 - k1_4, v4 - k4);

k2 = k1_3 + k2_4 + k3_5            //producten die je 2 maanden op voorraad houd, zijn van maand 1 naar 3 of van maand 2 naar 4 of van maand 3 tot 5
k1_3 = Math.Min(v1 - k4 - k1_4, v2 - k4 - k1_4 - k2_5);
k2_4 = Math.Min(v2 - k4 - k1_4 - k2_5 - k1_3 , v3 - k4 - k1_4 - k2_5);
k3_5 = Math.Min(v3 - k4 - k1_4 - k2_5 - k2_4, v4 - k4 - k2_5);

k1 = k1_2 + k2_3 + k3_4 + k4_5
k1_2 = v1 - k4 - k1_4 - k1_3;
k2_3 = v2 - k4 - k1_4 - k2_5 - k1_3 - k2_4;
k3_4 = v3 - k4 - k1_4 - k2_5 - k2_4 - k3_5;
k4_5 = v4 - k4 - k2_5 - k3_5; 

