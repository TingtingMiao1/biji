using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RankScore : MonoBehaviour
    {
        private List<Score1> _scoreDataList = new List<Score1>(); //创建list，用来存Score数据
        private Transform _scoreDataParent;//父物体
        private GameObject _socreItem;
        private Button _sortButton;
        private InputField _nameField;
        private InputField _scoreField;
        private bool _isFirstReader = true;
        // Start is called before the first frame update
        void Awake()
        {
            JudgementOrCreate();
            _scoreDataParent = GameObject.Find("/Canvas/ScoreRankList").transform;
            _sortButton = GameObject.Find("/Canvas/SortButton").GetComponent<Button>();
            _nameField = tijiaoshujv.
            _nameField.contentType = InputField.ContentType.Name;
            _scoreField = GameObject.Find("/Canvas/ScoreInputField").GetComponent<InputField>();
            _scoreField.contentType = InputField.ContentType.IntegerNumber;
        }
        void Start()
        {
            if (_isFirstReader)
            {
                ReaderJson();
                _isFirstReader = false;
            }

            if (_scoreDataParent.childCount > 0)
                for (int i = 0; i < _scoreDataParent.childCount; i++)
                {
                    GameObject a;
                    a = _scoreDataParent.GetChild(i).gameObject as GameObject;
                    Destroy(a);
                }
            _nameField.gameObject.SetActive(true);
            //_nameField.ActivateInputField();
            //_nameField.text = "";

            _scoreField.gameObject.SetActive(true);
            //_scoreField.text = null;

            _sortButton.transform.localPosition = new Vector3(0, -30f, 0);

            _sortButton.transform.GetChild(0).GetComponent<Text>().text = "SortData";

            ListenerInputField();
        }
        void ListenerInputField()
        {
            _sortButton.onClick.RemoveAllListeners();
            _sortButton.onClick.AddListener(
                () =>
                {
                    SortSetSomething();
                    ScoreSort();
                });
            _nameField.onEndEdit.RemoveAllListeners();
            _nameField.onEndEdit.AddListener(delegate { _scoreField.ActivateInputField(); });
            _scoreField.onEndEdit.RemoveAllListeners();
            _scoreField.onEndEdit.AddListener(
                delegate
                {
                    _scoreDataList.Add(new Score1(_nameField.text, Convert.ToInt32(_scoreField.text)));
                    SortSetSomething();
                    ScoreSort();
                });
        }
        /// <summary>
        /// 判断是否有排序文档，如果没有，创建一个空文档。本机地址，相对路径。
        /// </summary>
        void JudgementOrCreate()
        {
            if (File.Exists(Application.persistentDataPath + "/RankingList.txt"))
                Debug.Log("已有文件");
            else
                File.Open(Application.persistentDataPath + "/RankingList.txt", FileMode.Create);
            //Debug.Log(Application.persistentDataPath);路径根目录
        }
        /// <summary>
        /// 读取数据流
        /// </summary>
        void ReaderJson()
        {
            //StreamReader sr = new StreamReader(Application.dataPath + "/Resources/RankingList.txt");//发布之后还需自己创建RankingList.txt文档复制进Resource文件夹内，不方便，且易被更改。
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/RankingList.txt");
            string nextLine;
            while ((nextLine = sr.ReadLine()) != null)
                _scoreDataList.Add(JsonUtility.FromJson<Score1>(nextLine));
            sr.Close();//将所有存储的分数全部存到list中   分行存入
        }

        /// <summary>
        /// 排序、实例化并重新写入Json
        /// </summary>
        void ScoreSort()
        {
            _scoreDataList.Sort();

            //StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/RankingList.txt");//写入数据流
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/RankingList.txt");//写入数据流

            if (_scoreDataList.Count > 10)//排序后删除列表序列大于10的数据
                for (int i = 10; i <= _scoreDataList.Count; i++)
                    _scoreDataList.RemoveAt(i);

            foreach (Score1 t in _scoreDataList)
                sw.WriteLine(JsonUtility.ToJson(t));//重新写入排序后的json数据

            sw.Close();//写入结束

            InstantiateGo();

            for (int i = 0; i < _scoreDataList.Count; i++)
            {
                if (_scoreDataList[i].Name == _nameField.text)
                {
                    _scoreDataParent.GetChild(i).GetChild(0).GetComponent<Text>().color = Color.red;
                    _scoreDataParent.GetChild(i).GetChild(1).GetComponent<Text>().color = Color.red;
                    _scoreDataParent.GetChild(i).GetChild(2).GetComponent<Text>().color = Color.red;
                }
            }
        }
        /// <summary>
        /// 排序时的参数设置
        /// </summary>
        void SortSetSomething()
        {
            _nameField.gameObject.SetActive(false);
            _scoreField.gameObject.SetActive(false);
            _sortButton.transform.localPosition = new Vector3(361.5f, 205.5f, 0);
            _sortButton.transform.GetChild(0).GetComponent<Text>().text = "Back";
            _sortButton.onClick.RemoveAllListeners();
            _sortButton.onClick.AddListener(Start);
        }
        /// <summary>
        /// 实例化排名榜
        /// </summary>
        void InstantiateGo()//实例化排名榜
        {
            for (int i = 0; i < _scoreDataList.Count; i++)
            {
                _socreItem = Instantiate(Resources.Load<GameObject>("ScoreData")) as GameObject;
                _socreItem.gameObject.SetActive(true);
                _socreItem.transform.SetParent(_scoreDataParent, false);
                _socreItem.transform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();
                _socreItem.transform.Find("Name").GetComponent<Text>().text = _scoreDataList[i].Name;
                _socreItem.transform.Find("Score").GetComponent<Text>().text = _scoreDataList[i].GameScore.ToString();
            }
        }
       
    }
}
