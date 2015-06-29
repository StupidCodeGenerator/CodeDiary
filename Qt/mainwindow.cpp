#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    connect(ui->pushButton, SIGNAL(clicked()), this, SLOT(OnEnterPressed()));
}

MainWindow::~MainWindow()
{
    delete ui;
}

MainWindow::OnEnterPressed(){
    if (!MainWindow.fileName.isNull() && !MainWindow.fileName.isEmpty()){
        ui->textBrowser->append(ui->textEdit->toPlainText());
    } else {
        MainWindow::fileName = QFileDialog::getOpenFileName(this,
            tr("Open File"), "/home", tr("All Files (*.*)"));
    }
}
