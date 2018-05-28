using UnityEngine;
using System.Collections;

public class PerlinNoise {
	
	long seed;
	
	public PerlinNoise(long seed)
    {
		this.seed = seed;
	}
	
	private int PseudoRandom(long x, int range) //Псевдорандомное число
    {
		return (int)(((x+seed)^5) % range);
	}
	
	public int getNoise(int x, int range)
    {
        int chunkSize = 24; //Размер одного чанка
		
		float noise = 0;    //Величина шума
		
		range /= 2; //Сглаживаем высоты
		
		while(chunkSize > 0)
        {
			int chunkIndex = x / chunkSize; //Номер чанка
			
			float prog = (x % chunkSize) / (chunkSize * 1f);
			
			float left_random = PseudoRandom(chunkIndex, range);
			float right_random = PseudoRandom(chunkIndex + 1, range);

            noise += (1-prog) * left_random + prog * right_random;  //интерполяция величины шума

            chunkSize /= 2;
			range /= 2;
			
			range = Mathf.Max(1,range);
		}
		
		return (int)Mathf.Round(noise);
	}
}
