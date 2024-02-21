===========================================================================
【ソ フ ト名】 cobtojava  (COBOL to JAVA)
【ファイル名】 cobtojava.exe (Ver 1.0), cob_to_java_pre.pl (Ver 1.0)
【作  成  者】 Jokanji
【ソフト種別】 フリーウェア
===========================================================================
【はじめに】
ＣＯＢＯＬをJAVAに変換するツールです。主にバッチ系のＣＯＢＯＬプログラムが対象となります。
画面（オンライン）系のプログラムの変換は考えていません。また帳票（報告書）関係のプログラムの変換
もできません。それらをこの変換ツールにかけても、部分的な変換結果となります。
基本は、順、索引ファイル中心のバッチ処理の変換ツールです。
索引ファイルについては、ＲＤＢ（MySql,Oracle）テーブルに置き換えたものとして変換します。

【動作・開発環境】
　Windows 7 または 8.1    :Windows 環境
  JAVA1.8                 :JAVA 環境
　Active Perl             :Perl 環境(変換用)
  MySql,Oracle            :ＲＤＢ 環境(索引ファイル変換用)

【ファイル構成】
  cob_to_java_pre.pl　  :プレ変換プログラム(Perlで作成)
  cobtojava.exe         :変換実行プログラム(C#で作成)
　readme.txt            :この説明ファイル
  naiyou.txt            :内容説明ファイル
  cobtoj フォルダ       :パッケージディレクトリ※１　
  test_setumei フォルダ :テスト内容と説明　
  test_cobol フォルダ   :テスト用ＣＯＢＯＬプログラム

【動作・テスト環境】
 ・Windows 7
   JAVA        :1.8.0_73
   Active Perl :perl 5, version 20, subversion 2 (v5.20.2)
   MySql       :Server version: 5.5.11
   Oracle      :11g Express Edition Release 11.2.0.2.0 - 64bit Production

 ・Windows 8.1
   JAVA        :1.8.0_73
   Active Perl :perl 5, version 20, subversion 1 (v5.20.1)
   MySql       :Server version: 5.6.26-log
   Oracle      :11g Express Edition Release 11.2.0.2.0 - 64bit Production

【実行方法】
　①Active PerlとRDB(MySQLなど)が必要です。
    Active Perl → http://www.activestate.com/ (PATHを設定しておくと便利です)
    MySQL,Oracle → 各サイト

　②適当なフォルダ(例えばc:\cobtojava)に'cob_to_java_pre.pl','cobtojava.exe'を入れます。
　
　③パッケージディレクトリの作成とクラスパス設定など。
　　例えば、上記 c:\cobtojava の下に \cobtoj を作成。そこにjdbcファイル(xxx.jarなど)を
　　入れておきます。(例 mysql-connector-java-5.1.38-bin.jar, ojdbc6_g.jar など)
    パッケージディレクトリ(例 c:\cobtojava\cobtoj)に位置付けし、ＪＡＶＡクラスパス設定を行います。　
　　例 set CLASSPATH=c:\cobtojava\cobtoj;c:\cobtojava\cobtoj\mysql-connector-java-5.1.38-bin.jar
    
    このディレクトリに、ダウンロード、展開したcobtojフォルダ(【ファイル構成】の※１)の中から
    'cb','fd'フォルダを選択してここに入れて起きます。

　④ ②で作成したフォルダへ変換させるＣＯＢＯＬプログラムを入れます。
　　例えば'test01.cob'とします。

　⑤コマンドプロンプトでフォルダに位置づけます。そこで、プレ変換プログラム
　　'cob_to_java_pre.pl'を実行します。
    
    例 c:\cobtojava>perl cob_to_java_pre.pl test01.cob b 
       
  ⑥正常に動けば、'cobtojava_in.txt' ファイルが作成されています。

　⑦'cobtophp_in.txt'に対し、変換プログラム'cobtojava.exe'を実行します。
    正常に動けば、'dd.java'が作成されます。

    例 c:\cobtojava>cobtojava.exe cobtophp_in.txt
    
  ⑧ ③のパッケージディレクトリに'test01'フォルダを作成し、そこに⑦で変換生成された'dd.java'を入れます。

  ⑨テスト確認等。
　　コマンドプロンプトで'test01'フォルダに位置づけます。javac,java を実行。

    例 c:\cobtojava\cobtoj\test01>javac dd.java 
    
    例 c:\cobtojava\cobtoj\test01>java test01.dd  ←　実行 

【著作権および免責事項】
  本ソフトウェアの著作権は Jokanji にあります。
  本ソフトはフリーソフトです。個人、団体において自由にご使用ください。
　なお、本ソフトウェアを使用したことによって生じたすべての障害・損害等に関して、
　Jokanji は、一切の責任を負いません。各自の責任においてご使用ください。

【その他、再配布】
　本ソフトウェアの目的・内容から、これを複製または変更を加えるなどをし、再配布する等はあまり
　考えられない。よって、再配布は不可とします。

【お問い合わせ】
　お問い合わせは下記メールアドレスまでお願い致します。
  tomo_jokan-01@yahoo.co.jp

【履歴】
・cob_to_java_pre.pl (Ver 1.0) 2016.04.00start
・cobtojava.exe (Ver 1.0)      2016.04.00start

　以上

