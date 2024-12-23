using UnityEngine;

public class ExpCoin : MonoBehaviour
{
    [SerializeField] GainExperiance getExperiance;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coins collected");
        if (getExperiance != null)
        {
            getExperiance.GainExperiancePoints(10);
            Destroy(this.gameObject);
        }
    }
}
