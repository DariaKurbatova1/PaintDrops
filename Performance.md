Stop Watch times before improvement

Size & number of drops		|	Debug time	 |	Relaeas time
(489X480), 500				|	1108		 |	500
(1000X1000), 1000			|	4365		 |  1945
(2000X2000), 1500			|	9835		 |  4377
(1000X1000), 2000			|	17509		 |  7696

After improvement
Stop Watch times before improvement

Size & number of drops		|	Debug time	 |	Relaeas time
(489X480), 500				|	349		     |	253
(1000X1000), 1000			|	634		     |  373
(2000X2000), 1500			|	1162		 |  717
(1000X1000), 2000			|	1820		 |  1061


The performance improved by alot after marbling the paint drops in a parallel loop. 
Instead of :
for (int i = 0; i < Drops.Count; i++)
{
	Drops[i].Marble(Drops[i])
    if (Drops[i].BoundingBox.Intersect(surfaceBorder))
    {
        Drops.RemoveAt(i);
    }
}
Drops.Add(drop);

i did:
Parallel.For(0, Drops.Count, i =>
{
    Drops[i].Marble(Drops[i]);

});

for (int i = 0; i < Drops.Count; i++)
{

    if (Drops[i].BoundingBox.Intersect(surfaceBorder))
    {
        Drops.RemoveAt(i);
    }
}
Drops.Add(drop);