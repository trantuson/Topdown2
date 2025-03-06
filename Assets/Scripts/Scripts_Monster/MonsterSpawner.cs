using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [System.Serializable] 
    public class MonsterWave
    {
        public GameObject monsterPrefabs; // loại monster
        public int spawnCount; // số lượng monster trong wave
        public float spawnInterval; // Interval (Khoảng thời gian) spawn mỗi monster
    }

    [SerializeField] private Transform[] spawnPoint; // các điểm spawn ra monster (Random)
    [SerializeField] private List<MonsterWave> Listwaves; // danh sách các wave monster để spawn
    [SerializeField] private float timeBetweenWaves; // thời gian giữa các wave để spawn

    private int currentWaveIndex = 0; // biến lưu số wave hiện tại đang được spawn 

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    protected IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < Listwaves.Count) // nếu số wave hiện tại nhỏ hơn danh sách chứa wave thì tiếp tục spawn 
        {
            MonsterWave wave = Listwaves[currentWaveIndex]; // truy cập vào phần tử tại vị trí currentWaveIndex trong ds

            for(int i = 0; i < wave.spawnCount; i++) // lặp qua số lượng cần spawn của wave hiện tại 
            {
                // chọn vị trí ngẫu nhiên trong mảng spawnpoint
                int randomIndex = Random.Range(0, spawnPoint.Length);
                Transform spawnpoint = spawnPoint[randomIndex];

                // spawn
                Instantiate(wave.monsterPrefabs, spawnpoint.position, Quaternion.identity);

                // thời gian chờ để spawn monster trong wave hiện tại
                yield return new WaitForSeconds(wave.spawnInterval);
            }

            // thời gian chờ trước khi bắt đầu spawn wave mới khi đã spawn hết số lượng trong wave trước đó
            yield return new WaitForSeconds(timeBetweenWaves);

            // tăng số lượng wave (nếu hết wave trong danh sách chứa wave thì dừng hoặc spawn ra boss ...)
            currentWaveIndex++;
        }
    }
        

 }
