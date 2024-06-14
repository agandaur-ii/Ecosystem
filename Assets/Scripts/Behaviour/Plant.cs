using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : LivingEntity {
    public float plantGrowthRate = 0.01f;
   
    static List<Coord> availableGrowthLocations;
    
    protected virtual void Update () {
        if (canReproduce == false && this.transform.localScale[0] >= 1)
        {
            canReproduce = true;
        }

        if (AmountRemaining <= 0.1 && numberOfTimesReproduced == 0 && canReproduce)
        {
            SpawnNewPlants();
        }

        if (canReproduce == false && this.transform.localScale[0] < 1)
        {
            float growthAmount = Mathf.Min(plantGrowthRate, Time.deltaTime * 1 / 10);
            this.transform.localScale += Vector3.one * growthAmount;
        }
    }
    

    protected virtual void SpawnNewPlants()
    {
        var numberOfOffspring = LivingEntity.RandomNumberOfOffspring();

        // Get coord of plant
        var currentCoord = coord;

        // Get nearby walkable coords, depending on numberOfOffspring
        for (int i = 0; i < numberOfOffspring; i++)
        {
            var coordOne = Environment.GetNextTileRandom(currentCoord);
            var coordTwo = Environment.GetNextTileRandom(coordOne);

            // Spawn plants at those coords
            var entity = Instantiate(this);
            entity.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            entity.Init(coordTwo);
            entity.canReproduce = false;
            Environment.speciesMaps[entity.species].Add(entity, coordTwo);
        }

        numberOfTimesReproduced += 1;
        
    }
}