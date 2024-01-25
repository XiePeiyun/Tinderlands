using UnityEngine;
using UnityEngine.UI;

public class PageScrollView : MonoBehaviour
{
    ScrollRect rect;
    int pageCount;//页数
    Transform content;
    public float[] pages;//保存页面的位置
                         //public float moveTime = 0.3f;//可设置滚动时间

    private int currentPage = 0;//当前页
    private int perPageCount = 6;//每一页的item个数
    public Button nextBtn;
    public Button lastBtn;
    public float targePage;//目标页
    private bool isRoll;//控制滚动

    private void Start()
    {
        rect = GetComponent<ScrollRect>();
        if (rect == null)
            Debug.LogError("未查询到ScrollRect");
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

        //上一页
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
        //翻页
        if (isRoll)
        {
            if (Mathf.Abs(rect.horizontalNormalizedPosition - targePage) < 0.01f)
            {
                rect.horizontalNormalizedPosition = targePage;
                isRoll = false;
                return;
            }
            //设置水平滚动位置
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targePage, Time.timeScale * 0.1f);
        }
    }

}
