using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private GameObject _player;

    // Start is called before the first frame update
    private void Start()
    {
        _player = Instantiate(PlayerPrefab);
        var playerShootingBehaviour = _player.GetComponent<ShootingBehaviour>();
        playerShootingBehaviour.ShootingStrategy = new PlayerShootingStrategy();

        BulletBuilder.Instance.Initialize();
    }

}
