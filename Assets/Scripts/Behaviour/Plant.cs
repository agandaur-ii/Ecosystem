using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : LivingEntity {
    protected virtual void Update () {
        if (AmountRemaining <= 0.1 && numberOfTimesReproduced == 0)
        {
            SpawnNewPlants();
        }
    }

    private static int RandomNumberOfOffspring()
    {
        return Random.Range(1, 3);
    }
    protected virtual void SpawnNewPlants()
    {
        var numberOfOffspring = RandomNumberOfOffspring();
        Debug.Log("Number of Offspring: " + numberOfOffspring);
        // Get coord of plant
        var currentCoord = coord;
        // Get nearby walkable coords, depending on numberOfOffspring
        var listOfNearbyWalkableCoords = Environment.GetNextTileRandom(currentCoord);
        // Spawn plants at those coords
        var entity = Instantiate(this);
        entity.Init(listOfNearbyWalkableCoords);
        Environment.speciesMaps[entity.species].Add(entity, listOfNearbyWalkableCoords);

        numberOfTimesReproduced += 1;
        
    }
}