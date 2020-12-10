using System;

namespace Anlaysis_Infrastructure
{
    public class Const
    {
        public static readonly string BaseUrl = "http://hq.sinajs.cn/";

        public static readonly string Tops = "http://money.finance.sina.com.cn/quotes_service/api/json_v2.php/Market_Center.getHQNodeData?num=5&sort=changepercent&asc=0";

        public static readonly string Lasts = "http://money.finance.sina.com.cn/quotes_service/api/json_v2.php/Market_Center.getHQNodeData?num=5&sort=changepercent&asc=1";

        public static readonly string News = "http://zhibo.sina.com.cn/api/zhibo/feed?zhibo_id=152&id=&tag_id=0&page_size=5&type=0";
    }
}
