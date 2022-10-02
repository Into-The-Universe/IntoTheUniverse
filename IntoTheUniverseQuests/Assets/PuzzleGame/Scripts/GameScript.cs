using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform EmptySpace = null;
    [SerializeField] private List<GameObject> _tiles = new List<GameObject> ();

    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }
    
    void Update()
    {
        CheckIfWon();

        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                var distance = Vector2.Distance(EmptySpace.position, hit.transform.position);
                if (distance < 4)
                {
                    var lastEmptySpacePosition = EmptySpace.position;
                    var thisTile = hit.transform.GetComponent<TileScript>();
                    EmptySpace.position = thisTile.TargetPosition;
                    thisTile.TargetPosition = lastEmptySpacePosition;
                }
            }
        }
    }

    private void CheckIfWon()
    {
        var isWinner = true;
        for(var i = 0; i < _tiles.Count - 1; i++)
        {
            var script = _tiles[i].GetComponent<TileScript>();
            if (script.IsInCorrectPosition() == false)
            {
                isWinner = false;
                break;
            }
        }

        if (isWinner)
        {
            Debug.Log("Won!");
        }
    }

    private void Shuffle()
    {
        ////  var tileScript = _tiles[i].GetComponent<TileScript>();
        ////   var originalPosition = tileScript.la
        //for (var i = 0; i < _tiles.Count-1; i++)
        //{
        //    var tileScript = _tiles[i].GetComponent<TileScript>();
        //    tileScript.Start();
        //    var lastPosition = tileScript.TargetPosition;

        //    var randomIndex = Random.Range(0, _tiles.Count - 1);
        //    var randomTile = _tiles[randomIndex].GetComponent<TileScript>();
        //    randomTile.Start();

        //    tileScript.TargetPosition = randomTile.TargetPosition;
        //    randomTile.TargetPosition = lastPosition;
      //  }
    }
}