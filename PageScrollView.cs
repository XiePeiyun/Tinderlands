using UnityEngine;
using UnityEngine.UI;

public class PageScrollView : MonoBehaviour
{
    ScrollRect rect;
    int pageCount;//ҳ��
    Transform content;
    public float[] pages;//����ҳ���λ��
                         //public float moveTime = 0.3f;//�����ù���ʱ��

    private int currentPage = 0;//��ǰҳ
    private int perPageCount = 6;//ÿһҳ��item����
    public Button nextBtn;
    public Button lastBtn;
    public float targePage;//Ŀ��ҳ
    private bool isRoll;//���ƹ���

    private void Start()
    {
        rect = GetComponent<ScrollRect>();
        if (rect == null)
            Debug.LogError("δ��ѯ��ScrollRect");
        content = rect.transform.Find("Viewport/Content");
        pageCount = Mathf.CeilToInt(content.childCount / perPageCount) + 1;
        pages = new float[pageCount];
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i] = i * (1 / (float)(pageCount - 1));
        }

        nextBtn.onClick.AddListener(() =>
        {
            if (currentPage + 1 < pages.Length)
            {
                isRoll = true;
                targePage = pages[currentPage + 1];
                currentPage += 1;
                if (targePage > 1)
                    targePage = 1;
            }

        });

        //��һҳ
        lastBtn.onClick.AddListener(delegate
        {
            if (currentPage - 1 >= 0)
            {
                isRoll = true;
                targePage = pages[currentPage - 1];
                currentPage -= 1;
                if (targePage < 0)
                    targePage = 0;
            }

        });
    }



    private void Update()
    {
        //��ҳ
        if (isRoll)
        {
            if (Mathf.Abs(rect.horizontalNormalizedPosition - targePage) < 0.01f)
            {
                rect.horizontalNormalizedPosition = targePage;
                isRoll = false;
                return;
            }
            //����ˮƽ����λ��
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targePage, Time.timeScale * 0.1f);
        }
    }

}
