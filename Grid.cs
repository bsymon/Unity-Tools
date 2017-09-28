using UnityEngine;

namespace Game.World {

[System.Serializable]
public class Grid {
	
	public int width;
	public int height;
	public float _tileSize  = 1f;
	public bool _middleTile = false;
	public bool _2D         = false;
	
	// -- //
	
	public Vector3 GetWorldPosition(Vector2 gridPosition) {
		Vector3 position = Vector3.zero;
		float middle     = _middleTile ? _tileSize / 2f : 0f;
		
		position.x            = _tileSize * (int) gridPosition.x + middle;
		position[_2D ? 1 : 2] = _tileSize * (int) gridPosition.y + middle;
		
		return position;
	}
	
	public Vector2 GetGridPosition(Vector3 worldPosition) {
		Vector2 position = Vector2.zero;
		
		position.x = Mathf.Floor(worldPosition.x / _tileSize);
		position.y = Mathf.Floor(worldPosition[_2D ? 1 : 2] / _tileSize);
		
		return position;
	}
	
	public Vector2 From1DTo2D(int i) {
		return new Vector2(i % width, i / width);
	}
	
	public int From2DTo1D(Vector2 v) {
		return (int) (v.x + width * v.y);
	}
	
}

}
