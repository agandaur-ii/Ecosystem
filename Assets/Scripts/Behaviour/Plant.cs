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
        // Get coord of plant
        var currentCoord = coord;
        // Get nearby walkable coords, depending on numberOfOffspring
        var listOfNearbyWalkableCoords = Environment.GetNextTileRandom(currentCoord);
        // Spawn plants at those coords
        var entity = Instantiate(this);
        entity.transform.localScale = new Vector3(1, 1, 1);
        entity.Init(listOfNearbyWalkableCoords);
        Environment.speciesMaps[entity.species].Add(entity, listOfNearbyWalkableCoords);

        numberOfTimesReproduced += 1;
        
    }
}