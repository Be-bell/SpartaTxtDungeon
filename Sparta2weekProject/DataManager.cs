using Newtonsoft.Json;
using Sparta2weekProject.Objects.Charactor;
using System.IO;

namespace Sparta2weekProject
{
    public class DataManager
    {
        // 싱글톤 패턴
        private static DataManager instance;

        // 각 시스템 Docu에 저장.
        String userDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CreateFolder";

        //싱글톤으로 생성
        private DataManager() { }

        public static DataManager getInstnace()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }
            return instance;
        }

        // Charactor 변수만 받아 변수의 데이터를 저장.
        public void SaveCharactorToJson(Charactor _charactor)
        {
            //디렉토리가 없으면 디렉토리 생성.
            DirectoryInfo directoryInfo = new DirectoryInfo(userDocumentsFolder);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            // 디렉토리에 파일이 없으면 파일 생성.
            string filePath = Path.Combine(userDocumentsFolder, "Charactor.txt");
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }

            // json으로 직렬화하여 데이터 저장.
            string json = JsonConvert.SerializeObject(_charactor, Formatting.Indented);
            File.WriteAllText(filePath, json);

            // 저장 완료되면 나옴.
            Console.WriteLine("성공적으로 저장되었습니다!");
            Console.WriteLine("나가시려면 아무키나 누르세요.\n");
            Console.ReadLine();
            Console.Clear();
        }

        // 데이터 불러오기
        public Charactor LoadCharactorFromJson()
        {
            // 읽어올 파일 경로.
            string filePath = Path.Combine(userDocumentsFolder, "Charactor.txt");
            
            // 파일 없으면 캐릭터 생성 시작.
            if (!File.Exists(filePath))
            {
                Console.WriteLine("저장된 파일이 없습니다.");
                Console.WriteLine("캐릭터 생성을 시작합니다.");
                Console.WriteLine("");
                Console.ReadLine();
                Console.Clear();
                return null;
            }
            
            // 파일 있으면 불러오기.
            string json = File.ReadAllText(filePath);
            Charactor Loadcharactor = JsonConvert.DeserializeObject<Charactor>(json);
            switch(Loadcharactor.Class)
            {
                case CharactorClass.전사:
                    Loadcharactor.SkillBook = new WarriorSkillBook();
                    break;
                case CharactorClass.궁수:
                    Loadcharactor.SkillBook = new ArchorSkillBook();
                    break;
            }
            return Loadcharactor;
        }

    }
}
